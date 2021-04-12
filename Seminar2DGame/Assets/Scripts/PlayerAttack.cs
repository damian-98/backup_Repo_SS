/*
# 
# 1: Title: "HOW TO MAKE 2D MELEE COMBAT - EASY UNITY TUTORIAL" | Author: Blackthornprod | Source: https://www.youtube.com/watch?v=1QfxdUpVh5I&list=WL&index=85 | Date retrieved: 2/16/2021 @ 12:00 pm
#
# 2: Title: "Fire PROJECTILES in UNITY" | Author: BMo | Source: https://www.youtube.com/watch?v=uKWbNWPAZq4&list=WL&index=97 | Date retrieved: 2/22/2021 @ 12:00 am
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
    public Animator animator;

    public Transform FirePostion;
    public GameObject projectile;

    void Update(){
        //if(timeBtwAttack <= 0){// This if statement is saying if timeBtwAttack less or equal to 0 then attack.
            if(Input.GetKeyDown(KeyCode.Space)){//This if statement is giving input to the space bar to attack.
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);// This code will cast an invisible circle to a certain postion and radius to attack enemy.
                for(int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<EnemyAction>().TakeDamage(damage);// for loop will allow the enemy to take damage.
                }

                if(animator.GetFloat("Speed") < 0.01 && !animator.GetBool("Jumping"))
                {
                    FindObjectOfType<AudioManager>().Play("SwordSwhoosh");
                    animator.SetTrigger("Attack");
                }
            }
       /*  timeBtwAttack = startTimeBtwAttack;
        } else{
            timeBtwAttack -= Time.deltaTime;
        }*/


        // #2: ###########################################
        if(Input.GetKeyDown(KeyCode.M) && FireBallCounter.fireAmount>0)//This gets input from player to shoot fire balls.
        {
        Instantiate(projectile, FirePostion.position, FirePostion.rotation);// This line of code spawns a projectile and where to spawn the projectile.
            FireBallCounter.fireAmount -= 1;
            animator.SetTrigger("Cast");
        }
        // #2: ###########################################
    }


    void OnDrawGizmoSelected(){
        Gizmos.color = Color.red;// This Gizmos function just shows the point of attack point visibly in the scene view also shows up in red.
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
//####################################################################################################################################################