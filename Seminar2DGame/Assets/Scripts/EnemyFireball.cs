using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFireball : MonoBehaviour 
{

	public HealthBar Healthbar;// This is referencing my HealthBar script.
	private Transform Player;
	public float speed;
	private Vector2 target;
	public Animator animator;
	public GameObject gameOver;// This gameOver object will be used to hold the Game Over text.

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		target = new Vector2(Player.position.x, Player.position.y);
		gameOver.SetActive(false);// SetActive false means that the Game Over text will not pop up as soon as the game starts.
	}

	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position,target, speed * Time.deltaTime);

		if(transform.position.x == target.x && transform.position.y == target.y)
		{
			DestroyProjectile();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			DestroyProjectile();
			FindObjectOfType<AudioManager>().Play("PlayerHurt"); // The PlayerHurt sound will be played from this object.

        	Heart.numOfHearts -= 1;

        	if(Heart.numOfHearts <= 0) 	// This if block is saying if the num of hearts reach 0 then 
                                   		//the game will be over
        	{

            Time.timeScale = 0;

            FindObjectOfType<AudioManager>().Play("PlayerDeath");
			FindObjectOfType<AudioManager>().Play("GameOver");
			gameOver.SetActive(true);//SetActive true just enables the Game Over text.
            animator.SetBool("Dead", true);

        	}
		}
	}

	void DestroyProjectile()
	{
		Destroy(gameObject);
	}
}