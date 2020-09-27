using System.Collections.Generic;
using MapServices.Interfaces;
using UnityEngine;

namespace MapServices
{
    public class MapController : MonoBehaviour, IMapController
    {
        [SerializeField] private GameObject mapPrefab;
        private Map _map;

        public Transform GetPlayerSpawnPoint() => _map.GetPlayerSpawn();

        public List<Transform> GetEnemySpawnPoints() => _map.GetEnemySpawns();

        public void CreateMap()
        {
            var mapObject = Instantiate(mapPrefab);
            _map = mapObject.GetComponent<Map>();
            _map.BuildByReferences(mapObject.transform);
        }
    }
}