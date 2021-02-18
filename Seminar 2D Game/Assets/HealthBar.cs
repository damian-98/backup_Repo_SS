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
    public Slider Slider;
    public Color Low;//This displays the color bar for low health.
    public Color High;//This displays the color for high health.
    public Vector3 offset;// This helps for charaters that dont share the same height.

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);//This line of code makes it where if the enemy is lower than full health then the health bar will show.
        Slider.value = health;//This sets the current health.
        Slider.maxValue = maxHealth;//This sets the max health.

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);//This line of code sets the color of the health bar depending on how hard the enemy is.
    }

    void Start()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);//This code transforms from a 3D world postion to a 2D world postion. It's helps with movement.
    }
}
// ####################################################################################################################################################