using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CoinComponent : MonoBehaviour
{
    public int points;

    public int coinforhp = 10;
    public int removecoins = 10;
    public float coinhealing = 10;
    public Health health;

    public delegate void OnCoinChangedHandler(int amount, int changedAmount);
    public event OnCoinChangedHandler OnCoinChanged;

    public delegate void OnCoinInitHandler(int amount);
    public event OnCoinChangedHandler OnCoinInit;

    void Start()
    {
        OnCoinInit?.Invoke(0, 0);
    }
    public void AddPoints(int amount)
    {
        points += amount;
        //Debug.Log($"wow zebrales punkt, masz teraz {points} punktów");
        OnCoinChanged?.Invoke(points, amount);

        if (points == coinforhp)
        {
            AddPoints(-removecoins);
            health.AddHealing(coinhealing);
            OnCoinChanged?.Invoke(points, -removecoins);
            //Debug.Log($"Wow! Dosta³eœ {coinhealing} pkt ¿ycia, w zamian za {coinforhp} punktów");
        }
    }

}