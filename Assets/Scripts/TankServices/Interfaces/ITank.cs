using InputServices.Interfaces;

namespace TankServices.Interfaces
{
    public interface ITank
    {
        void Initialize(IInputController inputController);
    }
}