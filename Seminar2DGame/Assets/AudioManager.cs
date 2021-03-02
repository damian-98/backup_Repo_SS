/*
# 
# 1: Title: "Introduction to AUDIO in Unity" | Author: Brackeys | Source: https://www.youtube.com/watch?v=6OT43pvUyfY | Date retrieved: 2/24/2021 @ 1:05 pm
#
*/

// #1: ######################################################################################################
using UnityEngine.Audio;//This name space holds many of Unity's new audio features.
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;//This variable sounds will be an array of different
    //sounds that the user may want to add.

    void Awake()//In this case I used Awake method so that it immediately 
    //gets called the first time a GameObject is enabled.
    {
        foreach (Sound s in Sounds)//This for each loop is inatilinzing sound 
        //with s that I am curently using in the sounds array

        {
            s.source = gameObject.AddComponent<AudioSource>();//This line
            //is adding audio to the spefic game object that is being used.

            s.source.clip = s.clip;//This line is the clip of the audio source that we
            //are using.

            s.source.volume = s.volume;//This line is to control the volume of the audio source.
            s.source.pitch = s.pitch;//This line is to control the pitch of the audio source.
            s.source.loop = s.loop;//This will enable looping to the AudioManager.
        }
    }

    void Start()//Start method gets called immediately before the first 
    //frame that a GameObject is enabled.
    {
        Play("GameMusic");
    }

   public void Play (string name)
   {
       Sound s = Array.Find(Sounds,sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("Sound: " + name + " not found!!");
            return;
        }

       s.source.Play();//This array just loops through to find the appropriate
       //name of the sound being used on an object.
   }
}
// #1: ######################################################################################################
