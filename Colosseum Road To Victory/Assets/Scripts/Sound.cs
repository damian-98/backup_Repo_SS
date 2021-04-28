/*
# 
# 1: Title: "Introduction to AUDIO in Unity" | Author: Brackeys | Source: https://www.youtube.com/watch?v=6OT43pvUyfY | Date retrieved: 2/24/2021 @ 1:05 pm
#
*/

// #1: ######################################################################################################
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]//This type of name space is used when ever you
//create a custom class.

public class Sound
{
   public string name;//This will be public for the user to create 
   //specfic name for the audio clip.

   public AudioClip clip;//This will be public for the user to add
   //different audio clip of their choice to the game.

   [Range(0f, 1f)]//This line of code just creates a slider for the user to
   //adjust the volume. Also the 0f and 1f is just the ranges of low and high.

   public float volume;//This will be public for the user to change volume.

   [Range(.1f, 3f)]//This line of code is the same concept for the slider but just
   //for pitch.

   public float pitch;//This will be public for the user to change pitch.

   public bool loop;//This will be public for the user to enable loop.

    [HideInInspector]//This line of code just hides it from being public to the 
    //user in the inspector window.
    
   public AudioSource source;//This variable source needs to be public because
   //I will later access it in the AudioManager.cs script.
}
// #1: ######################################################################################################