using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInvun : MonoBehaviour
{
    public class Invunerable : MonoBehaviour
    {
        Renderer sRend;
        Color C;

        void Start()
        {
            sRend = GetComponent<Renderer>();
            C = sRend.material.color;
        }


        private void OnTrigger2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Enemy") && Heart.numOfHearts > 0)
            {
                StartCoroutine("Flash");
            }
        }


        IEnumerator Flash()
        {
            Physics2D.IgnoreLayerCollision(8, 10, true);
            C.a = 0.5f;
            sRend.material.color = C;
            yield return new WaitForSeconds(3f);
            Physics2D.IgnoreLayerCollision(8, 10, false);
            C.a = 1f;
            sRend.material.color = C;
        }
    }

}
