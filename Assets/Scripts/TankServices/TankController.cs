using TankServices.Interfaces;
using UnityEngine;

namespace TankServices
{
    /// <summary>
    /// Init tank prefab
    /// </summary>
    public class TankController : MonoBehaviour, ITankController
    {
        [SerializeField] private GameObject tank = null;

        // Start is called before the first frame update
        public Tank CreteTank()
        {
            // return Instantiate(tank);
            return null;
        }
    }
}
