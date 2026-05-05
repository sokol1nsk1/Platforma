using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements.Experimental;

public class Health : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    private bool invincibility;

    public CoinComponent CoinComp;

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
            //Debug.Log($"O nie, zabra³o ci {damage} pkt ¿ycia :(, zosta³o ci teraz {currentHealth} pkt ¿ycia");
            //Debug.Log("jesteœ teraz przez chwilê nieœmiertelny");
        }
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Game Over");
            //Debug.Log("wyrazy wspó³czucia");
        }
    }

    IEnumerator ResetInvicibility(float resetTime)
    {
        yield return new WaitForSeconds(resetTime);
        invincibility = false;
        //Debug.Log("reset - mo¿esz znowu dostaæ obra¿enia");
    }

    public void AddHealing(float healing)
    {
        currentHealth += healing;
        OnHealthChanged?.Invoke(currentHealth, healing);
        //Debug.Log($"Jupi, przywróci³o ci {healing} pkt ¿ycia :), masz teraz {currentHealth} pkt ¿ycia");
    }
}
