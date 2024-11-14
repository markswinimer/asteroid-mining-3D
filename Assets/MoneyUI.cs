using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI valueText;

    private PlayerShip _playerShip;

    void Start()
    {
        _playerShip = PlayerShip.Instance;
        _playerShip.OnMoneyChanged += UpdateMoney;
    }

    void OnDestroy()
    {
        _playerShip.OnMoneyChanged -= UpdateMoney;
    }
    
    public void UpdateMoney(int value)
    {
        valueText.text = value.ToString();
    }
}
