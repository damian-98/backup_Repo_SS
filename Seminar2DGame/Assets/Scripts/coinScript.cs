using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)//The OnTriggerEnter2D method is called
    //when a GameObject collides with another GameObject.
    {
       CoinCounter.coinAmount += 1;
       
       FindObjectOfType<AudioManager>().Play("CoinCollect");/* This line of code
       //just finds the object type that refrences the sound called CoinCollect.
       I also but that line before the Destroy method so it doesn't prevent 
       the sound from playing.*/

        Destroy(gameObject);
    }
}
