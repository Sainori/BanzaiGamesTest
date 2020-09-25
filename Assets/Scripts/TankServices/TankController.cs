using InputServices.Interfaces;
using TankServices.Interfaces;
using UnityEngine;

namespace TankServices
{
    public class TankController : MonoBehaviour, ITankController
    {
        [SerializeField] private GameObject tankPrefab = null;

        public Tank CreteTank(IInputController inputController)
        {
            var tankObject = Instantiate(tankPrefab);
            var tank = tankObject.GetComponent<Tank>();
            tank.Initialize(inputController);

            return tank;
        }
    }
}
