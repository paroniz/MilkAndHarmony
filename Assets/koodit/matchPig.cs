using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchPig : MonoBehaviour
{
    private Animator animator;
    public AudioClip light;
    public GameObject cannon;
    public float firetime = 5f;
    public float PickUpWait2 = 2f;
    public float throwwait = 2f;

    void Start ()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        firetime -= Time.deltaTime;
        LightMatch();
    }

    void LightMatch()
    {
        if (firetime <= 0f) 
        {
            StartCoroutine("Wait");
            firetime = 5f;
        }
    }

    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(throwwait);
        animator.SetTrigger("LightMatch");
        StartCoroutine("LightCannon");
    }
    IEnumerator LightCannon ()
    {
        animator.SetTrigger("LightCannon");
        yield return new WaitForSeconds(throwwait);
        cannon.GetComponent<cannon>().Shoot();
    }
}

