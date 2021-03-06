using System;
using InputServices.Interfaces;
using UnityEngine;

namespace InputServices
{
    public class InputController : MonoBehaviour, IInputController
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";
        public float HorizontalAxis { get; private set; }
        public float VerticalAxis { get; private set; }

        public Action OnNextWeapon { get; set; } = () => { };
        public Action OnPreviousWeapon { get; set; } = () => { };
        public Action OnSpace { get; set; } = () => { };
        public Action OnSpaceUp { get; set; } = () => { };
        public Action OnFire { get; set; } = () => { };
        public Action OnRestart { get; set; } = () => { };

        public Action OnEscape { get; set; } = () => { };

        public void DirectUpdate()
        {
            HorizontalAxis = Input.GetAxis(HorizontalAxisName);
            VerticalAxis = Input.GetAxis(VerticalAxisName);

            ProcessKeyInput(KeyCode.W, onKeyUp: OnNextWeapon);
            ProcessKeyInput(KeyCode.Q, onKeyUp: OnPreviousWeapon);
            ProcessKeyInput(KeyCode.Space, onKey: OnSpace, onKeyUp: OnSpaceUp);
            ProcessKeyInput(KeyCode.X, onKeyDown: OnFire);
            ProcessKeyInput(KeyCode.R, onKeyUp: OnRestart);
            ProcessKeyInput(KeyCode.Escape, onKeyUp:OnEscape);
        }

        public void Reset()
        {
            OnNextWeapon = () => { };
            OnPreviousWeapon = () => { };
            OnSpace = () => { };
            OnSpaceUp = () => { };
            OnFire = () => { };
            OnRestart = () => { };
            OnEscape = () => { };
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