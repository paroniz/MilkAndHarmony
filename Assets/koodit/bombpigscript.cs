using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombpigscript : MonoBehaviour
{
    public float bombspeed = 30f;
    public Animator animator;
    public Rigidbody2D bomb;
    public AudioClip bombthrow;
    public float firetime = 5f;

    void Update()
    {
        firetime -= Time.deltaTime;
        Shoot();
    }

    void Shoot()
    {
        if (firetime <= 0f) 
        {
            animator.SetTrigger("Throw");
            Rigidbody2D ammus = Instantiate(bomb, transform.position + new Vector3(0f, 2.0f, 0), transform.rotation);
            ammus.AddForce(new Vector2(-bombspeed,0), ForceMode2D.Impulse);
            firetime = 5f;
        }
    }
}

