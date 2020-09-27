using System.Collections.Generic;
using EnemyServices.Interfaces;
using UnityEngine;
using Random = System.Random;

namespace EnemyServices
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] private int maxEnemyCount = 10;
        [SerializeField] private GameObject enemyPrefab;

        [SerializeField] private List<Enemy> enemies = new List<Enemy>();

        private List<Transform> _spawnPoints;
        private System.Random _random;

        public void Initialize(List<Transform> spawnPoints)
        {
            _spawnPoints = spawnPoints;
            _random = new Random();
        }

        public void DirectUpdate()
        {
            if (enemies.Count >= maxEnemyCount)
            {
                return;
            }

            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            var enemyObject = Instantiate(enemyPrefab);
            enemyObject.transform.position = _spawnPoints[_random.Next(_spawnPoints.Count)].position;

            var enemy = enemyObject.GetComponent<Enemy>();
            enemies.Add(enemy);
            enemy.OnEnemyDestroy += enem1Y => { enemies.Remove(enem1Y); };
        }
    }
}