/*
# 
# 1: Title: "2D Easy Health Bars in Unity / 2021" | Author: Distorted Pixel Studios | Source: https://www.youtube.com/watch?v=v1UGTTeQzbo&list=WL&index=32&t=181s | Date retrieved: 2/12/2021 @ 11:15am
#
# 2: Title: "HOW TO MAKE 2D MELEE COMBAT - EASY UNITY TUTORIAL" | Author: Blackthornprod | Source: https://www.youtube.com/watch?v=1QfxdUpVh5I&list=WL&index=85 | Date retrieved: 2/16/2021 @ 12:00 pm
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
//    public GameObject bloodEffect;
    public float speed;
    private float dazedTime;// This variable will be used to daze the enemy while it is being attacked.
    public float startDazedTime; // This variable will be used to control how long the enemy will be dazed.

    void Start()
    {
        Hitpoints = MaxHitpoints;// This means what every number is set for hit points is also the same for max hit points.
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
    }
// #2: ####################################################################################################################################################
    void Update(){
        if(dazedTime <= 0){// This if else statement is saying if enemy is not dazed move at its normal speed but if dazed stop moving.
            speed = 5;
        } else {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if(Hitpoints <= 0){// This if statement is saying once the enemy gets hit to many time it will be disapear and get destoryed.
            Destroy(gameObject);
        }
    }

   public void TakeDamage(int damage){
       dazedTime = startDazedTime;
       Hitpoints -= damage;
       Debug.Log("damage taken");// This console log is just proof that I am hitting the enemy and that it is working.
   }
   // #2: ####################################################################################################################################################
}
// 1:####################################################################################################################################################