using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invunerable : MonoBehaviour
{

    float timer;
    private bool invincible = false;



    Material mWhite;
    Material mDefault;
    SpriteRenderer sRend;

    void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
        mDefault = sRend.material;
        mWhite = Resources.Load("New Material", typeof(Material)) as Material;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            invincible = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Ball"))
        {
            StartCoroutine("Flash");
            invinciblePeriod();
        }
    }

    void invinciblePeriod()
    {
        timer = 1;
        if (timer > 0)
        {
            invincible = true;
        }
    }

    IEnumerator Flash()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.25f);
            sRend.material = mWhite;
            Invoke("ResetMaterial", 0.15f);
        }
    }

    void ResetMaterial()
    {
        sRend.material = mDefault;
    }
}
