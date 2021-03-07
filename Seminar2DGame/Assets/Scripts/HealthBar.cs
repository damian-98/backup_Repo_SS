/*
# 
# 1: Title: "How to make a HEALTH BAR in Unity!" | Author: Brackeys | Source: https://www.youtube.com/watch?v=BLfNP4Sc_iA&list=WL&index=30&t=919s | Date retrieved: 2/18/2021 @ 11:15am
#
*/

// #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;// This is a reference to the slider component on the health bar to help move the halth bar.

    public void SetMaxHealth(int health, int maxHealth)//This method will help fill the float with the amount of health to the bar
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;// This will adjust to the value I set on the health bar.
        slider.maxValue = maxHealth;// This just sets the desired max value I want.
    }

    public void SetHealth(int health)
    {
       slider.value = health;
    }
}
// ####################################################################################################################################################