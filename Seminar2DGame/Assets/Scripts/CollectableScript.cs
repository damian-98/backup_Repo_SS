using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Potions"))
        {
            Heart.numOfHearts += 1;
            Destroy(collision.gameObject);
        }
    }
}
