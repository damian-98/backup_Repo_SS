using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitFinishLine : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject hitObj = other.gameObject;

        if (hitObj.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       
             }
    }
    
}
