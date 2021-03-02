﻿/*
# 
# 1: Title: "2D Easy Health Bars in Unity / 2021" | Author: Distorted Pixel Studios | Source: https://www.youtube.com/watch?v=v1UGTTeQzbo&list=WL&index=32&t=181s | Date retrieved: 2/12/2021 @ 11:15am
#
# 2: Title: "HOW TO MAKE 2D MELEE COMBAT - EASY UNITY TUTORIAL" | Author: Blackthornprod | Source: https://www.youtube.com/watch?v=1QfxdUpVh5I&list=WL&index=85 | Date retrieved: 2/16/2021 @ 12:00 pm
#
# 3: Title: "Easy HEALTH and SHIELD guide for UNITY | Unity Tutorial" | Author: KeySmash Studios | Source: https://www.youtube.com/watch?v=gLRupxv8AAw | Date retrieved: 3/1/2021 @ 11:45 am
#
*/

// #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
   public int Hitpoints;// This enables the user to set how many times it takes to hit to kill the enemy.
   public int MaxHitpoints = 5;//This sets the max hit points.
   public HealthBar Healthbar;// This is referencing my HealthBar script.

   public GameObject gameOver;// This gameOver object will be used to hold the Game Over text.

  

    void Start()
    {
        Hitpoints = MaxHitpoints;// This means what every number is set for hit points is also the same for max hit points.
        Healthbar.SetMaxHealth(Hitpoints, MaxHitpoints);
        gameOver.SetActive(false);// SetActive false means that the Game Over text will not pop up as soon as the game starts.
    }
// #2: ####################################################################################################################################################
   public void TakeDamage(int damage){
       Hitpoints -= damage;
       Healthbar.SetMaxHealth(Hitpoints, MaxHitpoints);
 
       if(Hitpoints <= 0){// This if statement is saying once the enemy gets hit to many time it will be disapear and get destoryed.
            FindObjectOfType<AudioManager>().Play("EnemyDeath");// The EnemyDeath sound will be played from this object.

           Destroy(gameObject);
        }
        
       Debug.Log("damage taken");// This console log is just proof that I am hitting the enemy and that it is working.
   }
    // #2: ####################################################################################################################################################
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Play("PlayerHurt");// The PlayerHurt sound will be played from this object.
        Heart.numOfHearts -= 1;

    // #3: ####################################################################################################################################################

        if(Heart.numOfHearts <= 0) // This if block is saying if the num of hearts reach 0 then 
                                    //the game will be over
        {
            Time.timeScale = 0; // Time.timeScale just means how much time has elapsed since a 
                                // certain moment.
                                
            gameOver.SetActive(true);//SetActive true just enables the Game Over text.
        }
     // #3: ####################################################################################################################################################

    }
}
// 1:####################################################################################################################################################