using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScreen : MonoBehaviour
{
    public void PlayAgain () 
   {
       SceneManager.LoadScene("Menu");
   }
  
}
