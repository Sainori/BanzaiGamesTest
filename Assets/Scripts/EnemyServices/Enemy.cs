using System;
using StatsServices;
using TankServices.Interfaces;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyServices
{
    public class Enemy : Character
    {
        [SerializeField] private float attackCooldown = 2;

        public Action<Enemy> OnEnemyDestroy = enemy => { };
        private NavMeshAgent _navMeshAgent;
        private ITank _tank;
        private float _delayLeft;
        private string _enemyTag;

        public void Initialize(ITank tank, string enemyTag)
        {
            _tank = tank;
            _enemyTag = enemyTag;
            _navMeshAgent = transform.GetComponent<NavMeshAgent>();
        }

        private void OnCollisionStay(Collision other)
        {
            if (_delayLeft > 0)
            {
                _delayLeft -= Time.deltaTime;
                return;
            }

            _delayLeft = attackCooldown;
            if (!other.gameObject.CompareTag(_enemyTag))
            {
                return;
            }

            var character = other.transform.GetComponent<Character>();
            if (character == null)
            {
                return;
            }

            character.TakeDamage(damage);
        }

        private void OnDestroy()
        {
            health = 0;
            OnEnemyDestroy(this);
        }

        public void DirectUpdate()
        {
            if (IsDead)
            {
                Destroy(gameObject);
                return;
            }

            if (!_navMeshAgent.isActiveAndEnabled)
            {
                return;
            }

            _navMeshAgent.SetDestination(_tank.GetCurrentWorldPos());
        }
    }

}