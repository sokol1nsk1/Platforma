using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Score : MonoBehaviour
{
    public float score;
    public float coinforhp = 10;
    public float removecoins = 10;
    public float coinHealing = 8;
    public Health health;
    public delegate void OnScoreChangedHandler(float newScore, float amountChanged);
    public event OnScoreChangedHandler OnScoreChanged;

    public delegate void OnScoreInitializedHandler(float score);
    public event OnScoreInitializedHandler OnScoreInitialized;

    void Start()
    {
        score = 0;
        OnScoreInitialized?.Invoke(score);
    }
    public void AddScore(float coinValue)
    {
        score += coinValue;
        OnScoreChanged?.Invoke(score, coinValue);
    }

    public void AddCoinHealing(float coinHealing)
    {
        if (score == coinforhp)
        {
            Debug.Log("usunpunktyzjebie");
           
            score = 0;
            OnScoreChanged?.Invoke(score, -removecoins);
        }

    }
}