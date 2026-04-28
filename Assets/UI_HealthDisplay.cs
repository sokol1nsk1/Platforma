using System;
using TMPro;
using UnityEngine;

public class UI_HealthDisplay : MonoBehaviour
{
    public Health health;
    public TextMeshProUGUI textComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        health.OnHealthChanged += OnHealthChanged;
        health.OnHealthInitialized += OnHealthInitialized;
    }

    private void OnHealthChanged(float newHealth, float amountChanged)
    {
        //Debug.Log(newHealth + ":" + amountChanged);
        textComponent.text = newHealth.ToString();
    }

    private void OnHealthInitialized(float currentHealth)
    {
        textComponent.text = currentHealth.ToString();
    }
}
