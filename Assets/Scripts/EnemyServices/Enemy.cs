using System;
using StatsServices;
using TankServices.Interfaces;
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

        public void Initialize(ITank tank)
        {
            _tank = tank;
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
            if (!other.gameObject.CompareTag("Player"))
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
            OnEnemyDestroy(this);
        }

        public void DirectUpdate()
        {
            if (IsDead)
            {
                Destroy(gameObject);
                return;
            }

            _navMeshAgent.SetDestination(_tank.GetCurrentWorldPos());
        }
    }

}