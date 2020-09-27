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
        private Random _random;
        private Transform _player;

        public void Initialize(List<Transform> spawnPoints, Transform player)
        {
            _spawnPoints = spawnPoints;
            _random = new Random();
            _player = player;
        }

        public void DirectUpdate()
        {
            enemies.ForEach(enemy => enemy.Attack());
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            if (enemies.Count >= maxEnemyCount)
            {
                return;
            }

            var enemyObject = Instantiate(enemyPrefab);
            enemyObject.transform.position = _spawnPoints[_random.Next(_spawnPoints.Count)].position;

            var enemy = enemyObject.GetComponent<Enemy>();
            enemies.Add(enemy);
            enemy.Initialize(_player);
            enemy.OnEnemyDestroy += enem1Y => { enemies.Remove(enem1Y); };
        }
    }
}