using UnityEngine;
using System.Collections.Generic;

public class StationPull : MonoBehaviour
{
    [SerializeField] private float pullStrength = 2f;  // Base strength of the pulling force
    [SerializeField] private float collectionRange = 0.5f;  // Distance at which ores are collected
    [SerializeField] private GameObject collectPoint;  // Target position for pulling ores
    [SerializeField] private Station _station;

    private List<GameObject> collectingOres = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collecting"))
        {
            // Add ore to the list if it's not already there
            if (!collectingOres.Contains(other.gameObject))
            {
                collectingOres.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collectingOres.Remove(other.gameObject);
    }

    private void Update()
    {
        // Continuously apply pulling force to all ores in the collectingOres list
        for (int i = collectingOres.Count - 1; i >= 0; i--)
        {
            GameObject ore = collectingOres[i];

            if (ore == null)
            {
                collectingOres.RemoveAt(i);
                continue;
            }

            PullOreTowardsCollectPoint(ore);
        }
    }

    private void PullOreTowardsCollectPoint(GameObject ore)
    {
        Rigidbody oreRb = ore.GetComponent<Rigidbody>();
        if (oreRb == null) return;

        float distanceToCollectPoint = Vector3.Distance(collectPoint.transform.position, ore.transform.position);

        if (distanceToCollectPoint <= collectionRange)
        {
            Ore oreData = ore.GetComponent<Ore>();
            // Collect ore and remove it from the list
            _station.HandleCollectOre(oreData);
            collectingOres.Remove(ore);
            Destroy(ore);
            return;
        }

        Vector3 directionToCollectPoint = (collectPoint.transform.position - ore.transform.position).normalized;
        float pullForce = pullStrength * Mathf.Clamp01(distanceToCollectPoint / collectionRange);

        oreRb.AddForce(directionToCollectPoint * pullForce);
    }
}