using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchPig : MonoBehaviour
{
    private Animator animator;
    public AudioClip lightMatch;
    public AudioClip litMatch;
    private AudioSource litMatchSource;
    private AudioSource lightMatchSource;
    public GameObject cannon;
    public float firetime = 5f;
    public float PickUpWait2 = 2f;
    public float throwwait = 2f;

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
        lightMatchSource.Play();
    }
}

