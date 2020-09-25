using System.Collections.Generic;
using InputServices.Interfaces;
using TankServices.Interfaces;
using UnityEngine;

namespace TankServices
{
    public class Tank : MonoBehaviour, ITank
    {
        [SerializeField] private AxleInfo frontAxle;
        [SerializeField] private AxleInfo backAxle;
        [SerializeField] private float maxMotorTorque = 400;
        [SerializeField] private float maxSteeringAngle = 30;
        [SerializeField] private int brakeForce = 400;
        [SerializeField] private GameObject tankShellPrefab;

        private List<AxleInfo> _axleInfos = new List<AxleInfo>();
        private IInputController _inputController;

        public void Initialize(IInputController inputController)
        {
            _inputController = inputController;

            _inputController.OnSpace += () => Brake(brakeForce);
            _inputController.OnSpaceUp += () => Brake(0);
            _inputController.OnFire += OnFire;

            _axleInfos.AddRange(new[] {frontAxle, backAxle});
        }

        private void Brake(int brakeForce)
        {
            backAxle.leftWheel.brakeTorque = brakeForce;
            backAxle.rightWheel.brakeTorque = brakeForce;
        }

        public void DirectUpdate()
        {
            UpdateMove();
        }

        private void UpdateMove()
        {
            var motor = maxMotorTorque * _inputController.VerticalAxis;
            var steering = maxSteeringAngle * _inputController.HorizontalAxis;

            foreach (var axleInfo in _axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }

                if (axleInfo.motor)
                {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
            }
        }

        private void OnFire()
        {
            var tankShell = Instantiate(tankShellPrefab, transform);
            tankShell.SetActive(true);
            var rigidbody = tankShell.GetComponent<Rigidbody>();
            rigidbody.AddForce(tankShell.transform.forward * 1000);

        }
    }
}