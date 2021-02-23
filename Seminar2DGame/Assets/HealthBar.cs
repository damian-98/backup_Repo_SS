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
    public Gradient gradient;// This just lets you be able to fill the health bar with different colors depending on how low the enemy health is.
    public Image fill;//This is just a refrence for the gradient.Evaluate.

    public void SetMaxHealth(int health, int maxHealth)//This method will help fill the float with the amount of health to the bar
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;// This will adjust to the value I set on the health bar.
        slider.maxValue = maxHealth;// This just sets the desired max value I want.

        fill.color = gradient.Evaluate(1f);// This controls what graident color will show. Ex 1f being green and 0f being red.
    }

    public void SetHealth(int health)
    {
       slider.value = health;

       fill.color = gradient.Evaluate(slider.normalizedValue);// This will just help change the gradient color depending on how much health the enemy has this happens because of slider.normalizedValue.
    }
}
// ####################################################################################################################################################