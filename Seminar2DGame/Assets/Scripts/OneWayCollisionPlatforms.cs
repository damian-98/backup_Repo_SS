/*
# 
# 1: Title: "ONE WAY COLLISION PLATFORMS - EASY UNITY TUTORIAL" | Author: Blackthornprod | Source: https://www.youtube.com/watch?v=M_kg7yjuhNg | Date retrieved: 3/15/2021 @ 2:15am
#
*/

// #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollisionPlatforms : MonoBehaviour
{
    private PlatformEffector2D effector; //The effector variable is refrencing the PlatformEffector2D component 

    public float waitTime; /* This variable will be used to judge how long it takes to press down key to get down 
                            off platform */

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>(); // Refrencing the PlatformEffector2D from the platform
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.DownArrow)){ /* This if statement just checks if the down key has been released
                                                  and if it has then waitTime goes back to 0.3f
                                                */
            waitTime = 0.1f;
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            if(waitTime <= 0){ /* This if statement is saying if waitTime is less or equal to 0 then platform will let player fall down
                                 and waitTime will be set back to 0.3f
                                */
                effector.rotationalOffset = 180f; // This line of code lets player fall underneath the platform
                waitTime = 0.1f;
            }else{
                waitTime -= Time.deltaTime; // This line of code will just slowly decrease waitTime if it isn't at 0
            }
        }

        if(Input.GetKey(KeyCode.UpArrow)){ /* This if statement just checks if up arrow is pressed then rotaitonalOffset
                                                will be set to 0 which means player will be able to jump from underneath to
                                                on top of a platform
                                            */
            effector.rotationalOffset = 0; // This line of code lets player jump on to platform from underneath
        }
    }
}
// #1: ####################################################################################################################################################
