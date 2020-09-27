using System.Collections.Generic;
using InputServices.Interfaces;
using StatsServices;
using TankServices.Interfaces;
using UnityEngine;

namespace TankServices
{
    public class Tank : Character, ITank
    {
        [SerializeField] private AxleInfo frontAxle;
        [SerializeField] private AxleInfo backAxle;
        [SerializeField] private float maxMotorTorque = 400;
        [SerializeField] private float maxSteeringAngle = 30;
        [SerializeField] private int brakeForce = 400;

        private List<AxleInfo> _axleInfos = new List<AxleInfo>();
        private IInputController _inputController;
        private IShootingController _shootingController;

        public void Initialize(IInputController inputController, IShootingController shootingController)
        {
            _inputController = inputController;
            _shootingController = shootingController;

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
            if (IsDead)
            {
                Time.timeScale = 0;
            }

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
            _shootingController.Shoot();
        }
    }
}