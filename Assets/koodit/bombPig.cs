﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombPig: MonoBehaviour
{
    public float speed = 30f;
    public float speedUp = 0.2f;
    public Animator animator;
    public Rigidbody2D bomb;
    public float fireTime = 5f;
    public float PickUpWaitTime = 0.5f;
    public float throwWait = 0.5f;

    void Update()
    {
        fireTime -= Time.deltaTime;
        Shoot();
    }

    void Shoot()
    {
        if (fireTime <= 0f) 
        {
            animator.SetTrigger("Throw");
            StartCoroutine("Wait");
            fireTime = 5f;
        }
    }

    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(throwWait);
        Rigidbody2D ammus = Instantiate(bomb, transform.position + new Vector3(0f, 0f, 0), transform.rotation);
        ammus.AddForce(new Vector2(speed, speedUp), ForceMode2D.Impulse);
        StartCoroutine("PickUpWait");
    }
    
    IEnumerator PickUpWait ()
    {
        animator.SetTrigger("PickBomb");
        yield return new WaitForSeconds(PickUpWaitTime);
        animator.SetTrigger("BackToIdle");
    }
}

