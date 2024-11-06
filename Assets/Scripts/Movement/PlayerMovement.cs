using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [SerializeField] private float _thrustForce = 10f;
    [SerializeField] private float _rotationSpeed = 100f; // Increase rotation speed for 3D
    [SerializeField] private float _maxVelocity = 5f;

    InputAction moveAction;
    InputAction boostAction;

    Vector2 moveInput;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        boostAction = InputSystem.actions.FindAction("Boost");
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        HandleRotation();
    }

    private void FixedUpdate()
    {
        ThrustForward(moveInput.y);
        ClampVelocity();
    }

    private void HandleRotation()
    {
        float rotationInput = moveInput.x;

        // Rotate around the Y-axis only
        _rigidBody.MoveRotation(_rigidBody.rotation * Quaternion.Euler(0, rotationInput * _rotationSpeed * Time.deltaTime, 0));
    }

    private void ThrustForward(float thrustAmount)
    {
        if (thrustAmount > 0)
        {
            // Apply thrust force in the forward (Z) direction of the ship
            Vector3 force = transform.forward * _thrustForce;
            _rigidBody.AddForce(force, ForceMode.Force);
        }
        else if (thrustAmount < 0)
        {
            if (_rigidBody.linearVelocity.magnitude > 0.1f)
            {
                Vector3 decelerationForce = -_rigidBody.linearVelocity.normalized * _thrustForce * 0.5f;
                _rigidBody.AddForce(decelerationForce, ForceMode.Force);
            }
            else
            {
                _rigidBody.linearVelocity = Vector3.zero;
            }
        }
        else
        {
            // Gradually slow down if there is no input
            _rigidBody.linearVelocity = Vector3.Lerp(_rigidBody.linearVelocity, Vector3.zero, Time.deltaTime * 0.5f);
        }
    }

    private void ClampVelocity()
    {
        // Clamp velocity magnitude
        if (_rigidBody.linearVelocity.magnitude > _maxVelocity)
        {
            _rigidBody.linearVelocity = _rigidBody.linearVelocity.normalized * _maxVelocity;
        }
    }
}