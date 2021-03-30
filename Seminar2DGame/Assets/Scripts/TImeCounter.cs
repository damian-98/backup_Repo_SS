 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImeCounter : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 120f;
    public GameObject gameOver;

    [SerializeField] Text countDown;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime; //makes it so when game starts, the current time is set to starting time.
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime; // the decrement of current time updates evrery frame. however we do not want that,
                                           // so we use Time.deltaTime to update evry second.
        countDown.text = currentTime.ToString("0");

        if (currentTime <= 3)
        {
            countDown.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0;

            gameOver.SetActive(true);//SetActive true just enables the Game Over text.
        }else{

            FindObjectOfType<AudioManager>().Play("GameOver");
        }
    }
}
