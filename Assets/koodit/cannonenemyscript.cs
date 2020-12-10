using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonenemyscript : MonoBehaviour
{
    public float shotspeed = 30f;
    public Animator animator;
    public Rigidbody2D projectile;
    public AudioClip shotsound;

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
            Rigidbody2D ammus = Instantiate(projectile, transform.position + new Vector3(0.6f, 0.2f, 0), transform.rotation);
            ammus.AddForce(new Vector2(-shotspeed,0), ForceMode2D.Impulse);
            firetime = 5f;
            Debug.Log("cannonshot");
        }
    }
}
