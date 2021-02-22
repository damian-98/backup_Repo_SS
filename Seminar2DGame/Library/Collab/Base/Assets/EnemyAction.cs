/*
# 
# 1: Title: "2D Easy Health Bars in Unity / 2021" | Author: Distorted Pixel Studios | Source: https://www.youtube.com/watch?v=v1UGTTeQzbo&list=WL&index=32&t=181s | Date retrieved: 2/12/2021 @ 11:15am
#
*/

// #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
   public float Hitpoints;// This enables the user to set how many times it takes to hit to kill the enemy.
   public float MaxHitpoints = 5;//This sets the max hit points.
   public HealthBar Healthbar;// This is referencing my HealthBar script.

    void Start()
    {
        Hitpoints = MaxHitpoints;// This means what every number is set for hit points is also the same for max hit points.
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }

   public void TakeHit(float damage)
   {
       Hitpoints -= damage;// This code is saying if enemy takes hits it takes damage.
       Healthbar.SetHealth(Hitpoints, MaxHitpoints);

       if (Hitpoints <= 0)// This if block is saying if hit points is less than equal to 0 then game object will be destoryed and disappeared from the game.
       {
        Destroy(gameObject);   
       }
   }
}
// ####################################################################################################################################################