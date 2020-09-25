using MapServices.Interfaces;
using UnityEngine;

namespace MapServices
{
    public class MapController : MonoBehaviour, IMapController
    {
        private const string Map = "Map";
        private Map _map;

        [SerializeField] private GameObject floor = null;

        public void CreateMap()
        {
            var mapObject = new GameObject(Map);
            _map =  mapObject.AddComponent<Map>();

            _map.AddFloor(floor);
        }
    }
}