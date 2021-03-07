 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TImeCounter : MonoBehaviour
{

    float currentTime;
    float startingTime;

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
    }
}
