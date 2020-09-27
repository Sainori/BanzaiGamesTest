using System;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyServices
{
    public class Enemy : MonoBehaviour
    {
        public Action<Enemy> OnEnemyDestroy = enemy => { };
        private NavMeshAgent _navMeshAgent;
        private Transform _player;

        public void Initialize(Transform player)
        {
            _player = player;
            _navMeshAgent = transform.GetComponent<NavMeshAgent>();
        }

        private void OnDestroy()
        {
            OnEnemyDestroy(this);
        }

        public void Attack()
        {
            _navMeshAgent.SetDestination(_player.position);
        }
    }

}