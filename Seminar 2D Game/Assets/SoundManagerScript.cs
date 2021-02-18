using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip CoinPickup;
    static AudioSource audioSrc;

    void Start()
    {
        // CoinPickup = Assets.Load<AudioClip>("CoinPickup");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "CoinPickUp":
                audioSrc.PlayOneShot(CoinPickup);
                break;
        }
    }
}
