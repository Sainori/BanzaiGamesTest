using MapServices.Interfaces;
using UnityEngine;

namespace MapServices
{
    public class MapController : MonoBehaviour, IMapController
    {
        private Map _map;

        /// <summary>
        /// 1. Нужно создать префаб с рефами, чтобы можно было редактировать позиции и повороты
        ///
        /// Специальный объект -> TransformReference (MonoBehaviour)
        ///
        /// Принцип работы:
        /// 1. загружаем префаб Map, берем компонент Map
        /// 2. через компонент Map получаем все точки и повороты объектов
        /// </summary>
        public void CreateMap()
        {
            // TODO: Create map object
            var mapObject = new GameObject();
            _map =  mapObject.AddComponent<Map>();
            _map.BuildByReferences();
        }
    }
}