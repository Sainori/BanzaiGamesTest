using InputServices.Interfaces;
using UnityEngine;

namespace TankServices.Interfaces
{
    public interface ITank
    {
        void Initialize(IInputController inputController, IShootingController shootingController);
        void DirectUpdate();
        Vector3 GetCurrentWorldPos();
        void Destroy();
    }
}