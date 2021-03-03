using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Heart.numOfHearts < 3)
        {
            if (collision.CompareTag("Potions"))
            {
                FindObjectOfType<AudioManager>().Play("Potions");
                Heart.numOfHearts += 1;
                Destroy(collision.gameObject);
            }
        }
        else if(Heart.numOfHearts == 3)
        {
            if (collision.CompareTag("Potions"))
            {
                FindObjectOfType<AudioManager>().Play("Potions");
                CoinCounter.coinAmount += 1;
                Destroy(collision.gameObject);
            }
        }
    }
}
