/*  #
    # 1: Title: "2D PLATFORMER PATROL AI WITH UNITY AND C# - EASY TUTORIAL" | Author: Blackthornprod | Source: https://www.youtube.com/watch?v=aRxuKoJH9Y0&list=WL&index=33&t=241s  | Date retrieved: 2/9/2021 @ 12:30 pm
    #
*/

// #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed; // Will control how fast the enemy moves.
    public float distance;// This will control how far the enemy will go.
    private bool movingRight = true; // THis will let the enemy know once it has reached its destination where to move to next.
    public Transform groundDectection;// This will detect where the  enemy is.

    void Update(){
        transform.Translate(Vector2.right * speed * Time.deltaTime);//This code makes the enemy move right.

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDectection.position, Vector2.down,distance);//This code will make the charater move left once it collides into the array. Also this code will determine if the array is collided to ground.
        if(groundInfo.collider == false){//This if else statement just checks if the array has acutually collided with something and this will make the enemy go left.
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;

            }
        }
    }
}

// ####################################################################################################################################################
