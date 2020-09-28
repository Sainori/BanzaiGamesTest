using InputServices.Interfaces;
using UnityEngine;

namespace TankServices.Interfaces
{
    public interface ITankController
    {
        ITank CreteTank(IInputController inputController, Transform spawnPoint);
    }
}