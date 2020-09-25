using System;
using InputServices.Interfaces;
using UnityEngine;

namespace InputServices
{
    public class InputController : MonoBehaviour, IInputController
    {
        public float HorizontalAxis { get; private set; }
        public float VerticalAxis { get; private set; }

        public Action OnRight { get; set; } = () => { };
        public Action OnLeft { get; set; } = () => { };
        public Action OnForward { get; set; } = () => { };
        public Action OnBackward { get; set; } = () => { };
        public Action OnSpace { get; set; } = () => { };
        public Action OnSpaceUp { get; set; } = () => { };
        public Action OnFire { get; set; } = () => { };

        public void DirectUpdate()
        {
            HorizontalAxis = Input.GetAxis("Horizontal");
            VerticalAxis = Input.GetAxis("Vertical");

            ProcessKeyInput(KeyCode.RightArrow, onKey: OnRight);
            ProcessKeyInput(KeyCode.LeftArrow, onKey: OnLeft);
            ProcessKeyInput(KeyCode.UpArrow, onKey: OnForward);
            ProcessKeyInput(KeyCode.DownArrow, onKey: OnBackward);
            ProcessKeyInput(KeyCode.Space, onKey: OnSpace, onKeyUp: OnSpaceUp);
            ProcessKeyInput(KeyCode.X, onKeyDown: OnFire);
        }

        private void ProcessKeyInput(KeyCode keyCode, Action onKeyDown = null, Action onKey = null, Action onKeyUp = null)
        {
            if (onKeyDown != null && Input.GetKeyDown(keyCode))
            {
                onKeyDown();
            }

            if (onKey != null && Input.GetKey(keyCode))
            {
                onKey();
            }

            if (onKeyUp != null && Input.GetKeyUp(keyCode))
            {
                onKeyUp();
            }
        }
    }
}