using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
   public void LevelOne()
   {
       SceneManager.LoadScene("IntroductoryLevelScene");
   }
   public void LevelTwo()
   {
       SceneManager.LoadScene("LevelTwo");
   }
   public void BossLevel()
   {
       SceneManager.LoadScene("BossLevel");
   }

}
