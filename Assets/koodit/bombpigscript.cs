using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombpigscript : MonoBehaviour
{
    public float luotinopeus = 30f;
    public Animator animator;
    public Rigidbody2D kuula;
    public AudioClip laukaus;

    public float ammussekunnit = 5f;

    void Start()
    {
       
    }

    void Update()
    {
        ammussekunnit -= Time.deltaTime;
        Shoot();
    }

    void Shoot()
    {
        if (ammussekunnit <= 0f) {
            animator.SetTrigger("Throw");
            Rigidbody2D ammus = Instantiate(kuula, transform.position + new Vector3(0f, 2.0f, 0), transform.rotation);
            ammus.AddForce(new Vector2(-luotinopeus,0), ForceMode2D.Impulse);
            ammussekunnit = 5f;
        }
    }
}

