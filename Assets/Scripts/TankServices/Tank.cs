using System.Collections.Generic;
using UnityEngine;

namespace TankServices
{
    public class Tank : MonoBehaviour
    {
        public List<AxleInfo> axleInfos; 
        public float maxMotorTorque;
        public float maxSteeringAngle;
        
        public void DirectUpdate()
        {
            float motor = maxMotorTorque * Input.GetAxis("Vertical");
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
     
            foreach (AxleInfo axleInfo in axleInfos) {
                if (axleInfo.steering) {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor) {
                    axleInfo.leftWheel.motorTorque = motor;
                    axleInfo.rightWheel.motorTorque = motor;
                }
                // ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                // ApplyLocalPositionToVisuals(axleInfo.rightWheel);
            }
        }
    }
}