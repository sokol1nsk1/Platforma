using System;
using TMPro;
using UnityEngine;

public class UI_HealthDisplay : MonoBehaviour
{
    public Health health;
    public TextMeshProUGUI textComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log(newHealth + ":" + amountChanged);
        textComponent.text = newHealth.ToString();
    }
}
