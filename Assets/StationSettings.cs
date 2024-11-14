using UnityEngine;

[CreateAssetMenu(fileName = "StationSettings", menuName = "StationSettings", order = 0)]
public class StationSettings : ScriptableObject {
    public string stationName;
    public int stationId;
    public int IronOrePrice;
    public int GoldOrePrice;

    public int GetOreValue(string oreType)
    {
        switch (oreType)
        {
            case "IronOre":
                return IronOrePrice;
            case "GoldOre":
                return GoldOrePrice;
            // Add cases for other ore types as needed
            default:
                return 0; // Default if ore type is unknown
        }
    }
}