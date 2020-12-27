using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb: MonoBehaviour
{
    public Animator animator;
    public AudioClip bombThrow;
    public AudioClip bombExplo;
    private AudioSource audioBombThrow;
    private AudioSource audio;
    private Collider2D bombCollider;
    private Rigidbody2D rb;
    private float bombAudioWait = 0;
    public float exploWait = 6f;
    public float colliderWait = 2f;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>(); 
        audio.volume = 0.7f;
        audio.maxDistance = 6f;
        audio.minDistance = 3f;
        bombCollider = GetComponent<Collider2D>(); 
        rb = GetComponent<Rigidbody2D>();
        audioBombThrow = gameObject.AddComponent<AudioSource>(); 
        audioBombThrow.clip = bombThrow;
        audioBombThrow.volume = 0.2f;
        audio.minDistance = 6 ;
        audio.maxDistance = 12;
        audio.spatialBlend = 1f;
        audio.spread = 180;
        audio.rolloffMode = AudioRolloffMode.Linear;
        audioBombThrow.Play();
    }

    void Update()
    {
        bombAudioWait -= Time.deltaTime;
    }

    IEnumerator Explo()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        //gameObject.SetActive(false);
        //StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2.6f);
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
    
    IEnumerator WaitAndExplo()
    { 
        yield return new WaitForSeconds(2);
        PlayAudio();
        animator.SetTrigger("InstantExplo");
        StartCoroutine("Destroy");
    }

    void PlayAudio()
    {
        if(bombAudioWait <= 0)
        {
            Debug.Log("playingauydio");
            audio.Play();
            bombAudioWait = 10f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioBombThrow.Stop();
        
        if (collision.gameObject.layer == 12)
        {
            PlayAudio();
            rb.gravityScale = 0.0f;
            animator.SetTrigger("InstantExplo");
            //StartCoroutine("colliderwait");
            StartCoroutine("Explo");
        }
        else
        {
            StartCoroutine("WaitAndExplo");
        } 

        rb.velocity=Vector3.zero; 
    }
}
