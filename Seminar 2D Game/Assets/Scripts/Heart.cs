using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;

    void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for(int i =0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = FullHeart;
            }

            if(i< numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
