using InputServices.Interfaces;
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

        public Tank CreteTank(IInputController inputController)
        {
            var tankObject = Instantiate(tank);
            // inputController.OnRight += () => { tankObject.transform.position += Vector3.right * Time.deltaTime; };
            // inputController.OnForward += () => { tankObject.transform.position += Vector3.forward * Time.deltaTime; };
            // inputController.OnBackward += () => { tankObject.transform.position += Vector3.back * Time.deltaTime; };
            // inputController.OnLeft += () => { tankObject.transform.position += Vector3.left * Time.deltaTime; };
            return tankObject.GetComponent<Tank>();
        }
    }
}
