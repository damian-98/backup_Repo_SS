using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGameOver : MonoBehaviour
{
     [SerializeField] Transform spawnPoint;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Awake()
    {
         Heart.numOfHearts -= 1;
            
             FindObjectOfType<AudioManager>().Play("PlayerHurt");
        if(Heart.numOfHearts == 0)
        {
                FindObjectOfType<AudioManager>().Play("GameOver");
           


            gameOver.SetActive(true);//SetActive true just enables the Game Over text.
        }
    }
 
        
    
}
