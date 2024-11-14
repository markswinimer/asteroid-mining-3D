using UnityEngine;

public class Station : MonoBehaviour
{
    [SerializeField] private StationSettings _stationSettings;

    public string stationName;
    public int stationId;

    private PlayerShip _playerShip;
    public bool _isCurrentStation;

    void Awake()
    {
        stationName = _stationSettings.stationName;
        stationId = _stationSettings.stationId;
        _playerShip = PlayerShip.Instance;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrent(bool value)
    {
        _isCurrentStation = value;
    }

    public void HandleCollectOre(Ore ore)
    {
        if (ore != null)
        {
            int oreValue = _stationSettings.GetOreValue(ore.OreType);
            Debug.Log(_playerShip);
            _playerShip.AddMoney(oreValue);
        }
        else
        {
            Debug.LogWarning("Collected item is not a valid ore!");
        }
    }
}
