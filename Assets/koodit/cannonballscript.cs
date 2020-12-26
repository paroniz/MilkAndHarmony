using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonballscript : MonoBehaviour
{
    private Animator ani = null;
    public float explowait = 0.5f;
    private AudioSource audio;
    public AudioClip shotSound;
    private bool audioPlayed = false;
    void Start()
    {
        this.ani = this.GetComponent<Animator>();
        audio = gameObject.AddComponent<AudioSource>(); 
        audio.clip = shotSound;
        audio.volume = 0.4f;
        audio.minDistance = 3;
        audio.maxDistance = 6;
        audio.spatialBlend = 1f;
        audio.spread = 180;
        audio.rolloffMode = AudioRolloffMode.Linear;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ani.SetTrigger("Explo");
        PlayExploAudio();
        StartCoroutine(explo());
    }

    IEnumerator explo()
    {
        yield return new WaitForSeconds(explowait);
        Destroy(gameObject);
    }

    void PlayExploAudio()
    {
        if (!audioPlayed)
        {
            audio.Play();
            audioPlayed = true;
        }
    }
}
