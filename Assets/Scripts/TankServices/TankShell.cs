using System;
using StatsServices;
using UnityEngine;

namespace TankServices
{
    public class TankShell : MonoBehaviour
    {
        public Action<TankShell> OnShoot { get; set; } = tankShell => { };
        public Action<TankShell> OnExplosion { get; set; } = tankShell => { };

        private int _damage;
        private Rigidbody _rigidbody;
        private string _enemyTag;

        public void Initialize(int shellDamage, string enemyTag)
        {
            _damage = shellDamage;
            _enemyTag = enemyTag;

            gameObject.SetActive(true);
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        public void ShootWithForce(int force)
        {
            OnShoot(this);
            _rigidbody.AddForce(transform.forward * force);
        }

        private void OnCollisionEnter(Collision other)
        {
            OnExplosion(this);
            if (!other.gameObject.CompareTag(_enemyTag))
            {
                return;
            }

            var character = other.transform.GetComponent<Character>();
            if (character == null)
            {
                return;
            }

            character.TakeDamage(_damage);
        }

        public void Deactivate()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;

            OnShoot = shell => { };
            OnExplosion = shell => { };

            gameObject.SetActive(false);
        }
    }
}