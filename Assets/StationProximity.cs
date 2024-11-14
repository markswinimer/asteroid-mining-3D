using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class StationProximity : MonoBehaviour
{
    private StationManager _stationManager;
    [SerializeField] private Station _station;
    
    void Awake()
    {
        _stationManager = StationManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerShip"))
        {
            _stationManager.SetCurrentStation(_station);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("PlayerShip"))
        {
            _stationManager.SetStationProximity(false);
        }
    }
}