/*
# 
# 1: Title: "SHOOTING/FOLLOW/RETREAT ENEMY AI WITH UNITY AND C# - EASY TUTORIAL" | Author: Blackthornprod| Source: https://www.youtube.com/watch?v=_Z1t7MNk0c4&list=WL&index=187 | Date retrieved: 4/12/2021 @ 3:05 pm
#
*/

// #1: ######################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

private float timeBtwShots; // This variable will be used to set how fast enemies will fire projectiles at a time.
public float startTimeBtwShots;	// This variable will be used to control how often enemies will fire.

public GameObject projectile; // This variable will be used to reference the gameObject tag projectile in Unity.

void Start()
{
	timeBtwShots = startTimeBtwShots;
}

void Update()
{
	if (timeBtwShots <= 0) // This if statement is saying if timeBtwShots less or equal to 0 then it will spawn a projectile
							// from the enemys position with no rotation
	{
		Instantiate(projectile, transform.position, Quaternion.identity);
		timeBtwShots = startTimeBtwShots; // This line of code will prevent the enemy from firing projectiles every frame.
		
	}else{

		timeBtwShots -= Time.deltaTime; //this line of code will just decrement how ever long enemies timeBtwShots is back to 0.
		

		}
	}
}
// #1: ######################################################################################################