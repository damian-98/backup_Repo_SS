/*
# 
# 1: Title: "HOW TO MAKE A WORKING 2D MOVING PLATFORM-Unity Tutorial" | Author: bblakeyyy | Source: https://www.youtube.com/watch?v=Q8Lb9IhqY0s&list=WL&index=70| Date retrieved: 2/11/2021 @ 10:00am
#
*/

// #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pos1; // this where the position for the moving platform will start.
    public Vector3 pos2;// this where the position for the moving platform will end.
    public float speed = 1.0f;// this will control how fast the moving platform is going.

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f)); // this code makes the moving platform move side to side starting at pos1 and end at pos2.
    }
}
// ####################################################################################################################################################
