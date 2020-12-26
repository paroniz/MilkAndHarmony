using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPig: MonoBehaviour
{
    public float bombspeed = 30f;
    public float bombspeedup = 0.2f;
    public Animator animator;
    public Rigidbody2D bomb;
    
    public float firetime = 5f;
    public float PickUpWait2 = 0.5f;
    public float throwwait = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        firetime -= Time.deltaTime;
        Shoot();
    }

    void Shoot()
    {
        if (firetime <= 0f) 
        {
            animator.SetTrigger("Throw");
            StartCoroutine("Wait");
            firetime = 5f;
        }
    }

    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(throwwait);
        Rigidbody2D ammus = Instantiate(bomb, transform.position + new Vector3(0f, 0f, 0), transform.rotation);
        ammus.AddForce(new Vector2(bombspeed,bombspeedup), ForceMode2D.Impulse);
        StartCoroutine("PickUpWait");
    }
    IEnumerator PickUpWait ()
    {
        animator.SetTrigger("PickBomb");
        yield return new WaitForSeconds(PickUpWait2);
        animator.SetTrigger("BackToIdle");
    }
}

