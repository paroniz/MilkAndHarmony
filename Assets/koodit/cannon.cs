﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour
{
    public float shotspeed = 30f;
    public Animator animator;
    public Rigidbody2D projectile;
    private AudioSource audio;
    public AudioClip shotSound;
    public float firetime = 5f;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>(); 
        audio.clip = shotSound;
        audio.volume = 0.4f;
        audio.minDistance = 10;
        audio.maxDistance = 12;
        audio.spatialBlend = 1f;
        audio.spread = 180;
        audio.rolloffMode = AudioRolloffMode.Linear;
    }

    public void Shoot()
    {
        //if (firetime <= 0f) 
        //{
            audio.Play();
            animator.SetTrigger("Throw");
            Rigidbody2D ammus = Instantiate(projectile, transform.position + new Vector3(0, 0.2f, 0), transform.rotation);
            ammus.AddForce(new Vector2(-shotspeed,0), ForceMode2D.Impulse);
            firetime = 5f;
           // Debug.Log("cannonshot");
        //}
    }
}
