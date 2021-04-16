using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)//The OnTriggerEnter2D method is called
    //when a GameObject collides with another GameObject.
    {
        FireBallCounter.fireAmount += 1;
        Destroy(gameObject);
    }
}
