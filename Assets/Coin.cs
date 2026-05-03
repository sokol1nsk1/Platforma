using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Coin : MonoBehaviour
{
    public int point = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger Enter");
        //Destroy(collision.gameObject);
        collision.GetComponent<CoinComponent>().AddPoints(point);
        Destroy(gameObject);
    }
}
