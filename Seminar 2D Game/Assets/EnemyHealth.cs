// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyHealth : MonoBehaviour
// {
//     public float maxHealth = 100;
//     public float currentHealth;

//     public HealthBar hp;

//     void Start()
//     {
//         currentHealth = maxHealth;
//         hp.SetMaxHealth(maxHealth);
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             TakeDamage(20);
//         }
//     }

//     void TakeDamage(float damage)
//     {
//         currentHealth -= damage;

//         hp.SetHealth(currentHealth);
//     }
// }
