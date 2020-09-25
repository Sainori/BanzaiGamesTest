using InputServices.Interfaces;

namespace TankServices.Interfaces
{
    public interface ITankController
    {
        Tank CreteTank(IInputController inputController);
    }
}