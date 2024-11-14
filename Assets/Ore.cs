using UnityEngine;

public class Ore : MonoBehaviour
{
    public string OreType;
    public string description;

    private Rigidbody _rigidBody; // Changed to Rigidbody for 3D

    void Awake()
    {
        if (_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // Rotate around the Y-axis for a more natural 3D spin effect
        transform.Rotate(Vector3.up * Time.deltaTime * 10);

        // Gradually slow down the ore’s velocity
        _rigidBody.linearVelocity = Vector3.Lerp(_rigidBody.linearVelocity, Vector3.zero, Time.deltaTime * 0.5f);
    }

    public void ApplyForce(Vector3 forceDirection) // Changed to Vector3 for 3D force application
    {
        _rigidBody.AddForce(forceDirection, ForceMode.Impulse);
    }
}