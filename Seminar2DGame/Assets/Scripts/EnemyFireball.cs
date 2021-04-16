/*
# 
# 1: Title: "SHOOTING/FOLLOW/RETREAT ENEMY AI WITH UNITY AND C# - EASY TUTORIAL" | Author: Blackthornprod| Source: https://www.youtube.com/watch?v=_Z1t7MNk0c4&list=WL&index=187 | Date retrieved: 4/12/2021 @ 3:05 pm
#
*/

// #1: ######################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Using Unity's UI library to use the gameOver text

public class EnemyFireball : MonoBehaviour
{

	private HealthBar Healthbar;// This is referencing my HealthBar script to  access player health.
	private Transform Player;
	public float speed; // Variable to control the speed of projectile
	private Vector2 target;
	public GameObject gameOver;// This gameOver object will be used to hold the Game Over text.

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform; // This line of code is going to just find the gameObject with tag Player.
		target = new Vector2(Player.position.x, Player.position.y);// This line of code is going to find the gameObject with tag Player position of its x&y axis.
		gameOver.SetActive(false);// SetActive false means that the Game Over text will not pop up as soon as the game starts.
	}

	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);// This line of code is going to make the projectile move towards
																									 // gameObject tag "Player" position.

		if (transform.position.x == target.x && transform.position.y == target.y) // This if block is saying if the projectile is equal to the same postion of
																				  // gameObject tag Player then when projectile reaches player postion
																				  // the projectile will get destoryed.

		{
			DestroyProjectile();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
		FindObjectOfType<AudioManager>().Play("PlayerHurt");// The PlayerHurt sound will be played from this object.
		Heart.numOfHearts -= 1;
		// #3: ####################################################################################################################################################

		if (Heart.numOfHearts <= 0) // This if block is saying if the num of hearts reach 0 then 
									//the game will be over
		{
			FindObjectOfType<AudioManager>().Play("PlayerDeath");
			FindObjectOfType<AudioManager>().Play("GameOver");

			gameOver.SetActive(true);//SetActive true just enables the Game Over text.
			Time.timeScale = 0;
		}
	}
		// #3: ####################################################################################################################################################


	void DestroyProjectile() // inside this function is a Destroy gameObject method that 
							 // I created in the update method to destroy the projectile
							 // when it finds target gameObject tag Player position.
	{
		Destroy(gameObject);
	}
}
// #1: ######################################################################################################