using UnityEngine;
using UnityEngine.Events;

public class PlayerShip : MonoBehaviour 
{
    public static PlayerShip Instance { get; private set; }
    
    public int CurrentMoney;
    public UnityAction<int> OnMoneyChanged;

    private void Awake() 
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate PlayerShip instance found! Destroying the new one.");
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddMoney(int amount)
    {
        CurrentMoney += amount;
        OnMoneyChanged?.Invoke(CurrentMoney);
    }
}