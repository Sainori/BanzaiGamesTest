using System;
using UnityEngine;

namespace TankServices
{
    public class TankShell : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public Action<TankShell> OnShoot { get; set; } = tankShell => { };
        public Action<TankShell> OnExplosion { get; set; } = tankShell => { };

        public void Initialize()
        {
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