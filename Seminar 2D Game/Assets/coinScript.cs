﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("Player")){
        SoundManagerScript.PlaySound("CoinPickup");
        Destroy(gameObject);

        }
    }
}
