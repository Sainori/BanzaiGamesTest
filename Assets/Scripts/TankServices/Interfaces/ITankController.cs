using InputServices.Interfaces;
using UnityEngine;

namespace TankServices.Interfaces
{
    public interface ITankController
    {
        Tank CreteTank(IInputController inputController, Transform spawnPoint);
    }
}