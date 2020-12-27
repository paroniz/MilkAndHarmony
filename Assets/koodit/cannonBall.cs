using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBall : MonoBehaviour
{
   
    public AudioClip shotSound;
    private Animator ani = null;
    private AudioSource audio;
    public float exploWait = 0.5f;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        ani.SetTrigger("Explo");
        PlayExploAudio();
        StartCoroutine(Explo());
    }

    IEnumerator Explo()
    {
        yield return new WaitForSeconds(exploWait);
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
