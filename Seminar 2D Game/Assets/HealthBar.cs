/*
# 
# 1: Title: "2D Easy Health Bars in Unity / 2021" | Author: Distorted Pixel Studios | Source: https://www.youtube.com/watch?v=v1UGTTeQzbo&list=WL&index=32&t=181s | Date retrieved: 2/12/2021 @ 11:15am
#
*/

// #1: ####################################################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
       slider.value = health;

       fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
// ####################################################################################################################################################