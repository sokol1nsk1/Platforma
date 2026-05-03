using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CoinComponent : MonoBehaviour
{
    private int points;
    
    public delegate void OnCoinChangedHandler(int amount, int changedAmount);
    public event OnCoinChangedHandler OnCoinChanged;
    public event OnCoinChangedHandler OnCoinInit;

    void Start()
    {
        OnCoinInit?.Invoke(0, 0);
    }
    public void AddPoints(int amount)
    {
        points += amount;
        OnCoinChanged?.Invoke(points, amount);
    }
}