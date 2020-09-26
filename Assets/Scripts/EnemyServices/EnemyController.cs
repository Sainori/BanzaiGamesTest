using System.Collections.Generic;
using EnemyServices.Interfaces;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] private int maxEnemyCount = 1;
        [SerializeField] private GameObject enemyPrefab;

        private List<Enemy> _enemies = new List<Enemy>();

        public void DirectUpdate()
        {
            if (_enemies.Count >= maxEnemyCount)
            {
                return;
            }

            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            var enemyObject = Instantiate(enemyPrefab);
            var enemy = enemyObject.GetComponent<Enemy>();
            _enemies.Add(enemy);
        }
    }
}