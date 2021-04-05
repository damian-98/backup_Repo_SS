using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 InitialPos;
    bool ismovingback;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        InitialPos = transform.position;
    }

     void Update()
    {
        if (ismovingback)
            transform.position = Vector2.MoveTowards(transform.position, InitialPos, 20f * Time.deltaTime);

        if (transform.position.y == InitialPos.y)
            ismovingback = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && !ismovingback)
        {
            Invoke("DropPlatform", 0.5f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
        Invoke("GetPlatform", 4f);
    }

    void GetPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        ismovingback = true;
    }
}
