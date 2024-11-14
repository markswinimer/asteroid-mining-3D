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

    private bool _isPlayerInProximity = false; // Proximity flag

    private StationManager _stationManager;

    private void Awake()
    {
        removeOreAction = InputSystem.actions.FindAction("Interact1");
        _stationManager = StationManager.Instance;
        
        if (removeOreAction != null)
        {
            removeOreAction.Enable();
        }
    }

    private void Update()
    {
        _isPlayerInProximity = _stationManager.inStationProximity;
        if (_isPlayerInProximity && removeOreAction != null && removeOreAction.IsPressed())
        {
            RemoveAllOres();
            //remove all ore instantly
            releaseTimer = 0f;
        }
        else if (removeOreAction != null && removeOreAction.IsPressed())
        {
            releaseTimer += Time.deltaTime;
            if (releaseTimer >= releaseInterval || !isReleasingOres)
            {
                isReleasingOres = true;
                RemoveNewestOre();  // Regular ore release
                releaseTimer = 0f;
            }
        }
        else
        {
            isReleasingOres = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (activeLines.Count >= maxTetheredItems) return;

        if (other.gameObject.layer == LayerMask.NameToLayer(oreLayerName) && !other.CompareTag("Collecting"))
        {
            LineRenderer line = other.gameObject.GetComponent<LineRenderer>();
            if (line == null)
            {
                other.gameObject.tag = "Tethered";
                line = other.gameObject.AddComponent<LineRenderer>();
                ConfigureLineRenderer(line);
            }

            if (!activeLines.ContainsKey(other.gameObject))
            {
                activeLines.Add(other.gameObject, line);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (activeLines.ContainsKey(other.gameObject))
        {
            float distanceToShip = Vector3.Distance(other.transform.position, shipTransform.position);
            if (distanceToShip >= removeDistance)
            {
                Debug.Log("Ore removed from attraction sphere");
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

        if (distanceToShip < maxDistance)
        {
            if (!oreRb.isKinematic)
            {
                oreRb.isKinematic = true;
                oreRb.linearVelocity = Vector3.zero;
                oreRb.angularVelocity = Vector3.zero;
            }

            float rotationDampening = Mathf.Clamp01(distanceToAttractionPoint / maxDistance);
            ore.transform.rotation = Quaternion.Lerp(
                ore.transform.rotation,
                Quaternion.identity,
                (1 - rotationDampening) * Time.deltaTime
            );
        }
        else
        {
            oreRb.isKinematic = false;
            Vector3 directionToShip = (shipTransform.position - ore.transform.position).normalized;
            float dynamicPullStrength = pullStrength * Mathf.Clamp(distanceToShip / maxDistance, 0.1f, 1f);
            oreRb.AddForce(directionToShip * dynamicPullStrength);
        }
    }

    public void RemoveNewestOre()
    {
        Debug.Log("Removing newest ore");
        if (activeLines.Count > 0)
        {
            GameObject newestOre = null;
            foreach (var entry in activeLines)
            {
                newestOre = entry.Key;
            }

            if (newestOre != null)
            {
                RemoveOre(newestOre, "Untagged");
            }
        }
    }

    private void RemoveOre(GameObject ore, string tag = "Untagged")
    {
        Debug.Log("Removing 1 ore");
        if (!activeLines.ContainsKey(ore)) return;
        
        LineRenderer line = activeLines[ore];

        if (line != null)
        {
            Destroy(line);
        }

        ore.tag = tag;
        activeLines.Remove(ore);

        UntetherOre(ore);
    }

    public void RemoveAllOres()
    {
        Debug.Log("Removing all ores");
        if (!_isPlayerInProximity) return;

        foreach (var ore in new List<GameObject>(activeLines.Keys))
        {
            RemoveOre(ore, "Collecting");
        }
    }

    public void UntetherOre(GameObject ore)
    {
        Debug.Log("Untethering ore");
        Collider collider = ore.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
            collider.enabled = true;
        }
    }
}