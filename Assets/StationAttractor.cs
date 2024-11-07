using UnityEngine;
using System.Collections.Generic;

public class StationAttractor : MonoBehaviour
{
    [SerializeField] private string oreLayerName = "Ore";
    [SerializeField] private float pullStrength = 2f;  // Base strength of the pulling force
    [SerializeField] private float collectionRange = 0.5f;  // Distance at which ores are collected
    [SerializeField] private GameObject collectPoint;  // Target position for pulling ores
    [SerializeField] private Station _station;

    private List<GameObject> activeOres = new List<GameObject>();

    private void Update()
    {
        // Apply pulling force to all active ores
        foreach (var ore in new List<GameObject>(activeOres))
        {
            if (ore == null) continue;

            PullOreTowardsCollectPoint(ore);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is an ore (layer check only, no tag check)
        if (other.gameObject.layer == LayerMask.NameToLayer(oreLayerName))
        {
            // Add ore to the active list for continuous pulling
            if (!activeOres.Contains(other.gameObject))
            {
                activeOres.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove the ore from active list if it leaves the attraction sphere
        if (activeOres.Contains(other.gameObject))
        {
            activeOres.Remove(other.gameObject);
        }
    }

    private void PullOreTowardsCollectPoint(GameObject ore)
    {
        Rigidbody oreRb = ore.GetComponent<Rigidbody>();
        if (oreRb == null) return;

        float distanceToCollectPoint = Vector3.Distance(collectPoint.transform.position, ore.transform.position);

        // Check if the ore is within collection range
        if (distanceToCollectPoint <= collectionRange)
        {
            // Handle ore collection and destroy it
            _station.HandleCollectOre(ore);
            Destroy(ore);
            activeOres.Remove(ore);  // Remove ore from active list
            return;
        }

        // Pull ore towards the collectPoint
        Vector3 directionToCollectPoint = (collectPoint.transform.position - ore.transform.position).normalized;
        float pullForce = pullStrength * Mathf.Clamp01(distanceToCollectPoint / collectionRange);

        // Apply force to pull ore towards the collectPoint
        oreRb.AddForce(directionToCollectPoint * pullForce);
    }
}
