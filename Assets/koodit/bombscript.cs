using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombscript : MonoBehaviour
{

    public Animator animator;
    public float explowait = 6f;
    public float colliderwaittime = 2f;
    private Collider2D bombcollider;
    private Rigidbody2D rb;
    void Start()
    {
        bombcollider = GetComponent<Collider2D>(); 
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator explo()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        //gameObject.SetActive(false);
        //StartCoroutine("destroy");
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(2.6f);
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
    
    IEnumerator WaitAndExplo()
    {
        yield return new WaitForSeconds(2);
        animator.SetTrigger("InstantExplo");
        StartCoroutine("destroy");
    }

    // IEnumerator colliderwait()
    // {
    //     yield return new WaitForSeconds(colliderwaittime);
    //     Physics2D.IgnoreLayerCollision(11, 12, false); 
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            rb.gravityScale = 0.0f;
            animator.SetTrigger("InstantExplo");
            //StartCoroutine("colliderwait");
            StartCoroutine("explo");
        }
        else
        {
            StartCoroutine("WaitAndExplo");
        } 
        rb.velocity=Vector3.zero; 
    }
}
