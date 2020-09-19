using System;
using MapController.Interfaces;
using UnityEngine;

namespace MapController
{
    public class MapController : MonoBehaviour, IMapFactory
    {
        [SerializeField]
        private GameObject _floor;

        public Map CreateMap()
        {
            var map = new Map();
            map.AddFloor(_floor);
            // BuildProps();
            return map;
        }
    }
}