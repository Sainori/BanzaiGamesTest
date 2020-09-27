using System;
using StatsServices;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyServices
{
    public class Enemy : Character
    {
        public Action<Enemy> OnEnemyDestroy = enemy => { };
        private NavMeshAgent _navMeshAgent;
        private Transform _player;

        public void Initialize(Transform player)
        {
            _player = player;
            _navMeshAgent = transform.GetComponent<NavMeshAgent>();
        }

        private void OnCollisionEnter(Collision other)
        {
        }

        private void OnDestroy()
        {
            OnEnemyDestroy(this);
        }

        public void DirectUpdate()
        {
            if (IsDead)
            {
                OnEnemyDestroy(this);
                return;
            }

            _navMeshAgent.SetDestination(_player.position);
        }
    }

}