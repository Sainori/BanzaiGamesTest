using UnityEngine;

namespace MapController
{
    public class Map : MonoBehaviour
    {
        private GameObject _floor;

        public void AddFloor(GameObject floor)
        {
            _floor = Instantiate(floor);
        }
    }
}