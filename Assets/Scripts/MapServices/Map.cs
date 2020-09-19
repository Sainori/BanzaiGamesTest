using UnityEngine;

namespace MapServices
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