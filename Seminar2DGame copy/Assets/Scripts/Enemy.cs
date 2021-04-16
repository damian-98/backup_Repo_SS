using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)//The OnTriggerEnter2D method is called
    //when a GameObject collides with another GameObject.
    {
        EnemyCounter.enemyAmount += 1;
        Destroy(gameObject);
    }
}
