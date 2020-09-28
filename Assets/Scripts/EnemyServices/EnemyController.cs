using System.Collections.Generic;
using EnemyServices.Interfaces;
using TankServices.Interfaces;
using UnityEngine;
using Random = System.Random;

namespace EnemyServices
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        [SerializeField] private float spawnDelay = 0.5f;

        [SerializeField] private int maxEnemyCount = 10;
        [SerializeField] private List<GameObject> enemyPrefabs;

        [SerializeField] private List<Enemy> enemies = new List<Enemy>();

        private List<Transform> _spawnPoints;
        private Random _random;
        private ITank _tank;
        private float _delayLeft;

        public void Initialize(List<Transform> spawnPoints, ITank tank)
        {
            _spawnPoints = spawnPoints;
            _random = new Random();
            _tank = tank;
        }

        public void DirectUpdate()
        {
            UpdateEnemies();
            SpawnNewEnemy();
        }

        private void UpdateEnemies()
        {
            for (var index = 0; index < enemies.Count; index++)
            {
                var enemy = enemies[index];
                if (enemy == null || enemy.IsDead)
                {
                    enemies.Remove(enemy);
                    index--;
                }

                enemy.DirectUpdate();
            }
        }

        private void SpawnNewEnemy()
        {
            if (enemies.Count >= maxEnemyCount)
            {
                return;
            }

            if (_delayLeft > 0)
            {
                _delayLeft -= Time.deltaTime;
                return;
            }

            _delayLeft = spawnDelay;
            SetupNewEnemy();
        }

        private void SetupNewEnemy()
        {
            var enemyObject = Instantiate(enemyPrefabs[_random.Next(enemyPrefabs.Count)]);
            enemyObject.transform.position = _spawnPoints[_random.Next(_spawnPoints.Count)].position;

            var enemy = enemyObject.GetComponent<Enemy>();
            enemies.Add(enemy);
            enemy.Initialize(_tank);

            enemy.OnEnemyDestroy += destroyingEnemy => Destroy(destroyingEnemy.gameObject);
        }
    }
}