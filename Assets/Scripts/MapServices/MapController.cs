using System.Collections.Generic;
using MapServices.Interfaces;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace MapServices
{
    public class MapController : MonoBehaviour, IMapController
    {
        [SerializeField] private GameObject mapPrefab;
        [SerializeField] private NavMeshSurface navMeshSurface;
        private Map _map;

        public Transform GetPlayerSpawnPoint() => _map.GetPlayerSpawn();

        public List<Transform> GetEnemySpawnPoints() => _map.GetEnemySpawns();

        public void CreateMap()
        {
            var mapObject = Instantiate(mapPrefab);
            _map = mapObject.GetComponent<Map>();
            _map.BuildByReferences(mapObject.transform);
            navMeshSurface.BuildNavMesh();
        }

        public void DeleteMap()
        {
            navMeshSurface.RemoveData();
            _map.DeleteObjects();
            Destroy(_map.gameObject);
        }
    }
}