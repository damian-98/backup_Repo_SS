using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public Animator animator;

    public GameObject gameOver;// This gameOver object will be used to hold the Game Over text.
    public GameObject RetryGame;

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
                StartCoroutine("GameOver");
            }
        }
    }

    IEnumerator GameOver()
    {
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        FindObjectOfType<AudioManager>().Play("GameOver");
        animator.SetBool("Dead", true);
        yield return new WaitForSeconds(0.8f);
        gameOver.SetActive(true);//SetActive true just enables the Game Over text.
        RetryGame.SetActive(true);
        Time.timeScale = 0;
    }
}