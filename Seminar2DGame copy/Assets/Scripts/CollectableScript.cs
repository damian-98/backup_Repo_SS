using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Heart.numOfHearts < 3)//if statement that checks to see if heart isnt full and if it isnt it adds a heart
        {
            if (collision.CompareTag("Potions"))//check to see if the player collider box collided with the potion tag.
            {
                FindObjectOfType<AudioManager>().Play("Potions"); 
                Heart.numOfHearts += 1; //calls the Heartnumber from the Heart script and increments by 1
                Destroy(collision.gameObject);
            }
        }
        else if(Heart.numOfHearts == 3)//if statement that checks to see if heart is full and if it is instead of adding more it increase coin counter
        {
            if (collision.CompareTag("Potions"))//check to see if the player collider box collided with the potion tag.
            {
                FindObjectOfType<AudioManager>().Play("Potions");//play potion sounds
                CoinCounter.coinAmount += 1;//calls coinAmount element from the CoinCounter script.
                Destroy(collision.gameObject);
            }
        }
    }
}
