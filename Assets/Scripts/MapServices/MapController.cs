using MapServices.Interfaces;
using UnityEngine;

namespace MapServices
{
    public class MapController : MonoBehaviour, IMapController
    {
        [SerializeField] private GameObject mapPrefab;
        private Map _map;

        public void CreateMap()
        {
            var mapObject = Instantiate(mapPrefab);
            _map = mapObject.GetComponent<Map>();
            _map.BuildByReferences(mapObject.transform);
        }
    }
}