using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb: MonoBehaviour
{

    public Animator animator;
    public float explowait = 6f;
    public float colliderwaittime = 2f;
    private Collider2D bombcollider;
    private Rigidbody2D rb;
    public AudioClip bombExplo;
    private AudioSource audio;
    public AudioClip bombThrow;
    private AudioSource audioBombThrow;
    private float bombAudioWaitTime = 0;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>(); 
        //audio.clip = bombExplo;
        audio.volume = 0.7f;
        audio.maxDistance = 6f;
        audio.minDistance = 3f;
        bombcollider = GetComponent<Collider2D>(); 
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
        bombAudioWaitTime -= Time.deltaTime;
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
        PlayAudio();
        animator.SetTrigger("InstantExplo");
        StartCoroutine("destroy");
    }

    void PlayAudio()
    {
        if(bombAudioWaitTime <= 0)
        {
            Debug.Log("playingauydio");
            audio.Play();
            bombAudioWaitTime = 10f;
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
            StartCoroutine("explo");
        }
        else
        {
            StartCoroutine("WaitAndExplo");
        } 
        
        rb.velocity=Vector3.zero; 
    }
}
