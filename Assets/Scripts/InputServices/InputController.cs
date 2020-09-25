using System;
using InputServices.Interfaces;
using UnityEngine;

namespace InputServices
{
    public class InputController : MonoBehaviour, IInputController
    {
        public float HorizontalAxis { get; private set; }
        public float VerticalAxis { get; private set; }

        public Action OnRight { get; set; }
        public Action OnLeft { get; set; }
        public Action OnForward { get; set; }
        public Action OnBackward { get; set; }


        public void DirectUpdate()
        {
            HorizontalAxis = Input.GetAxis("Horizontal");
            VerticalAxis = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.RightArrow))
            {
                OnRight();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                OnLeft();
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                OnForward();
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                OnBackward();
            }
        }
    }
}