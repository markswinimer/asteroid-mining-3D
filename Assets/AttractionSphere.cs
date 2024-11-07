using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;
public class AttractionSphere : MonoBehaviour
{
    [SerializeField] private string oreLayerName = "Ore";
    [SerializeField] private Transform shipTransform;  // Reference to the ship position
    [SerializeField] private float maxDistance = 3f;   // Maximum tether distance for strong pull
    [SerializeField] private float removeDistance = 5f; // Distance at which the ore is released
    [SerializeField] private float pullStrength = 2f;  // Base strength of the pulling force
    [SerializeField] private int maxTetheredItems;

    [SerializeField] private GameObject attractionPoint;

    private Dictionary<GameObject, LineRenderer> activeLines = new Dictionary<GameObject, LineRenderer>();
    private InputAction removeOreAction;
    private bool isReleasingOres = false;
    private float releaseTimer = 0f;
    private const float releaseInterval = 0.25f;

    private void Awake()
    {
        removeOreAction = InputSystem.actions.FindAction("Interact2");

        if (removeOreAction != null)
        {
            removeOreAction.Enable();  // Enable the action to listen for input
        }
        else
        {
            Debug.LogError("Remove ore action (Interact2) not found!");
        }
    }

    private void Update()
    {
        // Check if the Q key is held down
        if (removeOreAction != null && removeOreAction.IsPressed())
        {
            // Increment the timer
            releaseTimer += Time.deltaTime;

            // Check if the interval has passed
            if (releaseTimer >= releaseInterval || isReleasingOres == false)
            {
                isReleasingOres = true;
                // Release the newest ore
                RemoveNewestOre();

                // Reset the timer
                releaseTimer = 0f;
            }
        }
        else
        {
            isReleasingOres = false;
            // Reset the timer if the key is not held
            releaseTimer = 0f;
        }
        // Update lines and apply pulling force
        foreach (var oreEntry in new List<GameObject>(activeLines.Keys))
        {
            if (oreEntry == null) continue;

            LineRenderer line = activeLines[oreEntry];
            line.SetPosition(0, shipTransform.position);
            line.SetPosition(1, oreEntry.transform.position);

            PullOreWithDistanceEffect(oreEntry);
        }
    }

    private void OnTriggerEnter(Collider other) // Changed from OnTriggerEnter2D for 3D
    {
        Debug.Log("Trigger entered: " + other.gameObject.name);
        if (activeLines.Count >= maxTetheredItems) return;

        if (other.gameObject.layer == LayerMask.NameToLayer(oreLayerName))
        {
            LineRenderer line = other.gameObject.GetComponent<LineRenderer>();
            if (line == null)
            {
                other.gameObject.tag = "Tethered";

                // Add LineRenderer and configure it
                line = other.gameObject.AddComponent<LineRenderer>();
                ConfigureLineRenderer(line);
            }

            // Only add to activeLines if it’s not already in the dictionary
            if (!activeLines.ContainsKey(other.gameObject))
            {
                activeLines.Add(other.gameObject, line);
            }
        }
    }

    private void OnTriggerExit(Collider other) // Changed from OnTriggerExit2D for 3D
    {
        if (activeLines.ContainsKey(other.gameObject))
        {
            float distanceToShip = Vector3.Distance(other.transform.position, shipTransform.position);
            if (distanceToShip >= removeDistance)
            {
                RemoveOre(other.gameObject);
            }
        }
    }

    private void ConfigureLineRenderer(LineRenderer line)
    {
        line.startWidth = 0.05f;
        line.endWidth = 0.05f;
        line.positionCount = 2;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.cyan;
        line.endColor = Color.cyan;
    }

    private void PullOreWithDistanceEffect(GameObject ore)
    {
        Rigidbody oreRb = ore.GetComponent<Rigidbody>();
        if (oreRb == null) return;

        float distanceToShip = Vector3.Distance(shipTransform.position, ore.transform.position);
        float distanceToAttractionPoint = Vector3.Distance(attractionPoint.transform.position, ore.transform.position);

        // Check if the ore is within the maxDistance to the ship
        if (distanceToShip < maxDistance)
        {
            // Set Rigidbody to kinematic to stop affecting ship physics
            if (!oreRb.isKinematic)
            {
                // Set initial speed reference when ore becomes kinematic
                oreRb.isKinematic = true;
                oreRb.linearVelocity = Vector3.zero;  // Clear existing physics-based velocity
                oreRb.angularVelocity = Vector3.zero;  // Stop any rotation
            }

            // Gradually reduce rotation speed as it gets closer
            float rotationDampening = Mathf.Clamp01(distanceToAttractionPoint / maxDistance);
            ore.transform.rotation = Quaternion.Lerp(
                ore.transform.rotation,
                Quaternion.identity, // or another target rotation if desired
                (1 - rotationDampening) * Time.deltaTime
            );
        }
        else
        {
            // Switch to non-kinematic and apply force-based pulling towards the ship
            oreRb.isKinematic = false;

            // Apply a dynamic pull strength based on the distance for smooth effect
            Vector3 directionToShip = (shipTransform.position - ore.transform.position).normalized;
            float dynamicPullStrength = pullStrength * Mathf.Clamp(distanceToShip / maxDistance, 0.1f, 1f);
            oreRb.AddForce(directionToShip * dynamicPullStrength);
        }
    }

    private IEnumerator ReleaseOresContinuously()
    {
        while (true)
        {
            // Release one ore every 0.25 seconds
            RemoveNewestOre();
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void RemoveNewestOre()
    {
        if (activeLines.Count > 0)
        {
            GameObject newestOre = null;
            foreach (var entry in activeLines)
            {
                newestOre = entry.Key;
            }

            if (newestOre != null)
            {
                Debug.Log("should be removed");
                RemoveOre(newestOre);
            }
        }
    }

    private void RemoveOre(GameObject ore)
    {
        if (!activeLines.ContainsKey(ore)) return;
        Debug.Log("Removing ore: " + ore.name);
        LineRenderer line = activeLines[ore];
        Debug.Log("Removing line: " + line.name);
        if (line != null)
        {
            Destroy(line);
        }

        ore.tag = "Untagged";
        activeLines.Remove(ore);

        UntetherOre(ore);
    }

    public void UntetherOre(GameObject ore)
    {
        StartCoroutine(UntetherOreAfterDelay(ore, 2f)); // Start the coroutine with a 2-second delay
    }

    private IEnumerator UntetherOreAfterDelay(GameObject ore, float delay)
    {
        yield return new WaitForSeconds(delay);

        Collider collider = ore.GetComponent<Collider>(); // Changed from Collider2D for 3D
        if (collider != null)
        {
            collider.enabled = false;
            collider.enabled = true;
        }
    }
}
