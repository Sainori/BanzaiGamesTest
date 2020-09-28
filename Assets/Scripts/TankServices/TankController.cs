using InputServices.Interfaces;
using TankServices.Interfaces;
using UnityEngine;

namespace TankServices
{
    public class TankController : MonoBehaviour, ITankController
    {
        [SerializeField] private GameObject tankPrefab = null;
        private ITank _tank;

        public ITank CreteTank(IInputController inputController, Transform spawnPoint)
        {
            var tankObject = Instantiate(tankPrefab, spawnPoint.position, Quaternion.identity);
            var shootingController = tankObject.GetComponent<IShootingController>();

            _tank = tankObject.GetComponent<ITank>();
            _tank.Initialize(inputController, shootingController);
            return _tank;
        }

        public void DeleteTank()
        {
            _tank.Destroy();
            _tank = null;
        }

        public void DirectUpdate()
        {
            _tank.DirectUpdate();
        }
    }
}
