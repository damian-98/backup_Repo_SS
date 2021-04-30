using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossHealth : MonoBehaviour
{
    public int Hitpoints;// This enables the user to set how many times it takes to hit to kill the enemy.
    public int MaxHitpoints = 10;//This sets the max hit points.
    public HealthBar Healthbar;// This is referencing my HealthBar script.
    public Animator animator;

    void Start()
    {
        Hitpoints = MaxHitpoints;// This means what every number is set for hit points is also the same for max hit points.
        Healthbar.SetMaxHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeDamage(int damage)
    {
        Hitpoints -= damage;
        Healthbar.SetMaxHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 5)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (Hitpoints <= 0)
        {// This if statement is saying once the enemy gets hit to many time it will be disapear and get destoryed.
            FindObjectOfType<AudioManager>().Play("EnemyDeath");// The EnemyDeath sound will be played from this object

            Destroy(gameObject);
        }
        //    Debug.Log("damage taken");// This console log is just proof that I am hitting the enemy and that it is working.
    }
}
