using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements.Experimental;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private float currentHealth;
    private bool invincibility;

    public float coinforhp = 10;
    public float removecoins = 10;
    public float coinHealing = 5;

    public delegate void OnHealthChangedHandler(float newHealth, float amountChanged);
    public event OnHealthChangedHandler OnHealthChanged;

    public delegate void OnHealthInitializedHandler(float newHealth);
    public event OnHealthInitializedHandler OnHealthInitialized;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        OnHealthInitialized?.Invoke(currentHealth);
    }

    public void AddDamage(float damage)
    {
        if (!invincibility)
        {
            currentHealth -= damage;
            OnHealthChanged?.Invoke(currentHealth, damage);
            invincibility = true;
            StartCoroutine(ResetInvicibility(3));
        }
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator ResetInvicibility(float resetTime)
    {
        yield return new WaitForSeconds(resetTime);
        invincibility = false;
        Debug.Log("reset");
    }

    public void AddHealing(float healing)
    {
        currentHealth += healing;
        OnHealthChanged?.Invoke(currentHealth, healing);
        //Debug.Log(health);
    }
}
