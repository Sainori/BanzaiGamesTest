using MapServices.Interfaces;
using UnityEngine;

namespace MapServices
{
    public class MapController : MonoBehaviour, IMapController
    {
        [SerializeField] private GameObject floor = null;

        public Map CreateMap()
        {
            var map = new Map();
            map.AddFloor(floor);
            // BuildProps();
            return map;
        }
    }
}