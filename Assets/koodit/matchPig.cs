using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchPig : MonoBehaviour
{
    public AudioClip lightMatch;
    public AudioClip litMatch;
    private AudioSource litMatchSource;
    private AudioSource lightMatchSource;
    private Animator animator;
    public GameObject cannon;
    public float fireTime = 5f;
    public float pickUpWait = 2f;
    public float throwWait = 2f;

    void Start ()
    {
        lightMatchSource = gameObject.AddComponent<AudioSource>(); 
        lightMatchSource.clip = lightMatch;
        lightMatchSource.volume = 0.4f;
        litMatchSource = gameObject.AddComponent<AudioSource>(); 
        litMatchSource.clip = litMatch;
        litMatchSource.volume = 0.4f;
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        fireTime -= Time.deltaTime;
        LightMatch();
    }

    void LightMatch()
    {
        if (fireTime <= 0f) 
        {
            StartCoroutine("Wait");
            fireTime = 5f;
        }
    }

    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(throwWait);
        animator.SetTrigger("LightMatch");
        StartCoroutine("LightCannon");
    }
    
    IEnumerator LightCannon ()
    {
        animator.SetTrigger("LightCannon");
        yield return new WaitForSeconds(throwWait);
        cannon.GetComponent<cannon>().Shoot();
        lightMatchSource.Play();
    }
}

