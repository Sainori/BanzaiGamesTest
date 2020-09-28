using System;

namespace InputServices.Interfaces
{
    public interface IInputController
    {
        float HorizontalAxis { get; }
        float VerticalAxis { get; }

        Action OnNextWeapon { get; set; }
        Action OnPreviousWeapon { get; set; }

        Action OnSpace { get; set; }
        Action OnSpaceUp { get; set; }
        Action OnFire { get; set; }

        Action OnRestart { get; set; }

        void DirectUpdate();
        void Reset();
    }
}