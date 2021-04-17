using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPickupSound : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D col)
    {
        FindObjectOfType<AudioManager>().Play("FireBallPickUp");
    }
}
