using InputServices.Interfaces;
using TankServices.Interfaces;
using UnityEngine;

namespace TankServices
{
    public class TankController : MonoBehaviour, ITankController
    {
        [SerializeField] private GameObject tankPrefab = null;

        public ITank CreteTank(IInputController inputController, Transform spawnPoint)
        {
            var tankObject = Instantiate(tankPrefab, spawnPoint.position, Quaternion.identity);
            var shootingController = tankObject.GetComponent<IShootingController>();
            var tank = tankObject.GetComponent<ITank>();

            tank.Initialize(inputController, shootingController);

            return tank;
        }
    }
}
