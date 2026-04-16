using System.Collections;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Health : MonoBehaviour
{
    public float maxhealth = 100;
    private float currenthealth;
    private bool invincibility;

    public delegate void OnHealthChangedHandler(float newHealth, float amountChanged);
    public event OnHealthChangedHandler OnHealthChanged;

    public delegate void OnHealthInitializedHandler(float currentHealth);
    public event OnHealthInitializedHandler OnHealthInitialized;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenthealth = maxhealth;
        OnHealthInitialized?.Invoke(currenthealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddDamage(float damage)
    {
        if (!invincibility)
        {
            currenthealth -= damage;
            OnHealthChanged?.Invoke(currenthealth, damage);
            invincibility = true;
            StartCoroutine(ResetInvicibility(3));
        }
        if (currenthealth <= 0)
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
        currenthealth += healing;
        OnHealthChanged?.Invoke(currenthealth, healing);
        //Debug.Log(health);
    }
}
