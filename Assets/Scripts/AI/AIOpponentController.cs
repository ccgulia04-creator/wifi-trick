using System.Collections.Generic;
using UnityEngine;

namespace ApexRush.AI
{
    public class AIOpponentController : MonoBehaviour
    {
        public List<Transform> waypoints = new();
        public float waypointReachDistance = 8f;
        public float throttle = 0.9f;
        public float steeringSensitivity = 0.65f;
        public float maxSteering = 1f;

        private int _index;
        private ApexRush.Core.CarController _car;

        private void Awake()
        {
            _car = GetComponent<ApexRush.Core.CarController>();
        }

        private void Update()
        {
            if (waypoints.Count == 0 || _car == null) return;

            Transform target = waypoints[_index];
            Vector3 localTarget = transform.InverseTransformPoint(target.position);
            float steer = Mathf.Clamp(localTarget.x / localTarget.magnitude * steeringSensitivity, -maxSteering, maxSteering);

            SimulateInput(throttle, steer);

            if (Vector3.Distance(transform.position, target.position) < waypointReachDistance)
            {
                _index = (_index + 1) % waypoints.Count;
            }
        }

        private void SimulateInput(float t, float s)
        {
            // Replace with your Input abstraction for production code.
            // For prototype, we directly set wheel values through reflection-safe wrappers.
            var frontLeft = _car.frontLeft;
            var frontRight = _car.frontRight;
            var rearLeft = _car.rearLeft;
            var rearRight = _car.rearRight;

            frontLeft.steerAngle = _car.steerAngle * s;
            frontRight.steerAngle = _car.steerAngle * s;

            float speedFactor = Mathf.Clamp01(1f - (_car.SpeedKph / _car.maxSpeedKph));
            float torque = t * _car.accelerationForce * speedFactor;
            rearLeft.motorTorque = torque;
            rearRight.motorTorque = torque;
        }
    }
}
