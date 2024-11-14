using UnityEngine;
using UnityEngine.Events;

public class StationManager : MonoBehaviour {
    public static StationManager Instance;

    public Station _currentStation;
    
    public bool inStationProximity;

    public UnityAction<bool> OnProximityChanged;

    private void Awake() {
        Instance = this;
    }
    
    public void SetCurrentStation(Station station) {
        _currentStation = station;
        _currentStation.SetCurrent(true);
        SetStationProximity(true);
    }

    public void SetStationProximity(bool value) {
        inStationProximity = value;
        OnProximityChanged?.Invoke(inStationProximity);
    }
}