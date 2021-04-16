using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineSound : MonoBehaviour
{
    // Update is called once per frame
     private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().Play("TrampolineBounce");
    }
}
