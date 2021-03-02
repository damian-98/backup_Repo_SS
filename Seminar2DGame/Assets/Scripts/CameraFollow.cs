/*  #
    # 1: Title: "2D Camera Follow in Unity | 2D Game Dev Tutorial" | Author: Muddy Wolf Games | Source: https://www.youtube.com/watch?v=kAlo_pGF178&list=WL&index=48 | Date retrieved: 2/4/2021 @ 1:00 pm
    #
*/

// #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target; // Variable target will follow the target which is the Player. 
   public Vector3 cameraOffset; // cameraOffset variable is used to keep the camera in postion where it dosent leave the Player.
   public float followSpeed = 10f; // This followSpeed variable will determine how fast the camera will follow the target which is the Player.
   public float xMin = 0f; // This xMin variable which is initialized to 0f just sets the camera to postion 0.
   Vector3 velocity = Vector3.zero; // This piece of code just sits as a refrence when we use Vector3.SmoothDamp.

   void FixedUpdate(){
       Vector3 targetPos = target.position + cameraOffset; // This line of code just makes the camera follow the Player.
       Vector3 clampPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, float.MaxValue), targetPos.y, targetPos.z); // This line of code justs controlles how the camera will follow the target.
       Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampPos, ref velocity, followSpeed * Time.fixedDeltaTime); // This line of code just takes the current postion of the target and sets how fast the camera will follow behind the target.
       
       transform.position = smoothPos;
   } 
}
// ####################################################################################################################################################
