using System.Collections.Generic;
using TankServices;
using UnityEngine;

namespace MapServices
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private List<ObjectReference> objectReferences = new List<ObjectReference>();
        [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private List<Transform> enemySpawnPoints;

        public Transform GetPlayerSpawn() => playerSpawnPoint;

        public List<Transform> GetEnemySpawns() => enemySpawnPoints;

        public void BuildByReferences(Transform mapTransform)
        {
            foreach (var reference in objectReferences)
            {
                if (reference == null)
                {
                    Debug.LogError("Can't create object: reference is null.");
                }

                var referenceTransform = reference.transform;
                gameObjects.Add(Instantiate(reference.prefab, referenceTransform.position, referenceTransform.rotation, mapTransform));
            }
        }
    }
}