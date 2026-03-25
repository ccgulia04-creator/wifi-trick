using UnityEngine;

namespace ApexRush.Core
{
    [RequireComponent(typeof(Rigidbody))]
    public class CarController : MonoBehaviour
    {
        [Header("Performance")]
        public float maxSpeedKph = 360f;
        public float accelerationForce = 12000f;
        public float brakeForce = 20000f;
        public float steerAngle = 32f;
        public float driftGripFactor = 0.82f;

        [Header("Wheel Colliders")]
        public WheelCollider frontLeft;
        public WheelCollider frontRight;
        public WheelCollider rearLeft;
        public WheelCollider rearRight;

        [Header("Nitro")]
        public float nitroMultiplier = 1.3f;
        public float nitroSeconds = 4f;

        private Rigidbody _rb;
        private float _throttle;
        private float _brake;
        private float _steer;
        private bool _drift;
        private bool _nitro;
        private float _nitroRemaining;

        public float SpeedKph => _rb.linearVelocity.magnitude * 3.6f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.centerOfMass = new Vector3(0f, -0.45f, 0f);
        }

        private void Update()
        {
            _throttle = Input.GetAxis("Vertical");
            _steer = Input.GetAxis("Horizontal");
            _brake = Input.GetKey(KeyCode.Space) ? 1f : 0f;
            _drift = Input.GetKey(KeyCode.LeftShift);

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                _nitro = true;
                _nitroRemaining = nitroSeconds;
            }
        }

        private void FixedUpdate()
        {
            ApplySteering();
            ApplyDrive();
            ApplyBrakes();
            ApplyDriftModel();
            HandleNitro();
        }

        private void ApplySteering()
        {
            float targetSteer = steerAngle * _steer;
            frontLeft.steerAngle = targetSteer;
            frontRight.steerAngle = targetSteer;
        }

        private void ApplyDrive()
        {
            float speedFactor = Mathf.Clamp01(1f - (SpeedKph / maxSpeedKph));
            float boost = _nitro ? nitroMultiplier : 1f;
            float torque = _throttle * accelerationForce * speedFactor * boost;

            rearLeft.motorTorque = torque;
            rearRight.motorTorque = torque;
        }

        private void ApplyBrakes()
        {
            float appliedBrake = _brake * brakeForce;
            frontLeft.brakeTorque = appliedBrake;
            frontRight.brakeTorque = appliedBrake;
            rearLeft.brakeTorque = appliedBrake;
            rearRight.brakeTorque = appliedBrake;
        }

        private void ApplyDriftModel()
        {
            if (!_drift) return;

            WheelFrictionCurve lateral = rearLeft.sidewaysFriction;
            lateral.stiffness = driftGripFactor;
            rearLeft.sidewaysFriction = lateral;
            rearRight.sidewaysFriction = lateral;
        }

        private void HandleNitro()
        {
            if (!_nitro) return;
            _nitroRemaining -= Time.fixedDeltaTime;
            if (_nitroRemaining <= 0f)
            {
                _nitro = false;
            }
        }
    }
}
