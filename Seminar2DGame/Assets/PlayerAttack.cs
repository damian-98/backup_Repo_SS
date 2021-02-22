﻿/*
# 
# 1: Title: "HOW TO MAKE 2D MELEE COMBAT - EASY UNITY TUTORIAL" | Author: Blackthornprod | Source: https://www.youtube.com/watch?v=1QfxdUpVh5I&list=WL&index=85 | Date retrieved: 2/16/2021 @ 12:00 pm
#
*/

// #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;//This variable will be used to slow down the rate of player attack on enemy.
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;// This variable will let us scoop out all eniemes in the cirles radius of attack.
    public float attackRange;
    public int damage;

    void Update(){
        if(timeBtwAttack <= 0){// This if statement is saying if timeBtwAttack less or equal to 0 then attack.
            if(Input.GetKey(KeyCode.Space)){//This if statement is giving input to the space bar to attack.
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);// This code will cast an invisible circle to a certain postion and radius to attack enemy.
                for(int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<EnemyAction>().TakeDamage(damage);// for loop will allow the enemy to take damage.
                }
         }
         timeBtwAttack = startTimeBtwAttack;
        } else{
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmoSelected(){
        Gizmos.color = Color.red;// This Gizmos function just shows the point of attack point visibly in the scene view also shows up in red.
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
//####################################################################################################################################################