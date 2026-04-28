using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Points : MonoBehaviour
{
    public float coinValue = 1;
    public float coinHealing = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger Enter");
        //Destroy(collision.gameObject);
        collision.GetComponent<Score>().AddScore(coinValue);
        Destroy(gameObject);
    }
}
