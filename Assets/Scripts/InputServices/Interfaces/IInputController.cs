using System;

namespace InputServices.Interfaces
{
    public interface IInputController
    {
        float HorizontalAxis { get; }
        float VerticalAxis { get; }

        Action OnRight { get; set; }
        Action OnLeft { get; set; }
        Action OnForward { get; set; }
        Action OnBackward { get; set; }

        Action OnSpace { get; set; }
        Action OnSpaceUp { get; set; }

        void DirectUpdate();
    }
}