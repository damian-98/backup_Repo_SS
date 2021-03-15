using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlocks : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<PlayerMovement>() &&
            collision.contacts[0].normal.y > 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
