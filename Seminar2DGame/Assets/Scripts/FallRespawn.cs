using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    public GameObject gameOver;// This gameOver object will be used to hold the Game Over text.

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.position = spawnPoint.position;
            Heart.numOfHearts -= 1;
            
             FindObjectOfType<AudioManager>().Play("PlayerHurt");
            if(Heart.numOfHearts <= 0) // This if block is saying if the num of hearts reach 0 then 
                                    //the game will be over
            {
             Time.timeScale = 0; // Time.timeScale just means how much time has elapsed since a 
                                // certain moment.

            FindObjectOfType<AudioManager>().Play("GameOver");
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            gameOver.SetActive(true);//SetActive true just enables the Game Over text.
            }
        }
    }
}