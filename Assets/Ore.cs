using UnityEngine;

public class Ore : MonoBehaviour
{
    public string OreType;
    public string description;

    private Rigidbody _rigidBody; // Changed to Rigidbody for 3D

    private Collider _collider;
    private float tagTimer = 0f; // Timer to track "Collecting" tag duration
    private const float retriggerTime = 3f; // Time threshold for retriggering

    void Awake()
    {
        if (_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody>();
        }
        _collider = GetComponent<Collider>();
    }

  void Update()
    {
        // Check if the ore has the "Collecting" tag and increment timer
        if (CompareTag("Collecting"))
        {
            if (_rigidBody.isKinematic)
            {
                _rigidBody.isKinematic = false;
            }
            
            tagTimer += Time.deltaTime;
            
            // Retrigger collider if "Collecting" tag has been active for more than retriggerTime
            if (tagTimer >= retriggerTime)
            {
                RetriggerCollider();
                tagTimer = 0f; // Reset the timer after retriggering
            }
        }
        else
        {
            tagTimer = 0f; // Reset the timer if the tag is not "Collecting"
        }

        // Rotate around the Y-axis for a natural 3D spin effect
        transform.Rotate(Vector3.up * Time.deltaTime * 10);

        // Gradually slow down the ore’s velocity
        _rigidBody.linearVelocity = Vector3.Lerp(_rigidBody.linearVelocity, Vector3.zero, Time.deltaTime * 0.5f);
    }

    public void ApplyForce(Vector3 forceDirection)
    {
        _rigidBody.AddForce(forceDirection, ForceMode.Impulse);
    }

    private void RetriggerCollider()
    {
        if (_collider != null)
        {
            _collider.enabled = false;
            _collider.enabled = true; // Re-enable to retrigger nearby colliders
            Debug.Log("Collider retriggered for nearby detection.");
        }
    }
}