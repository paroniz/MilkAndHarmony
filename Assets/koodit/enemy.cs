using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject coin;
    public AudioClip gettingHit;
    private AudioSource audio;
    public int maxHealth = 100;
    public int goldCount = 50;
    private int currentHealth;
    private bool stepSoundPlaying = false;

    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>(); 
        audio.clip = gettingHit;
        audio.volume = 1f;
        //InvokeRepeating("walkSound", 0, 0.2f);
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        audio.Play();
        animator.SetTrigger("Hurt");

        if(currentHealth <=0)
        {
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        Debug.Log("Enemy died!");
        //animator.SetTrigger("CannonShot");
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        GameObject coinInstance = Instantiate(coin, transform.position + new Vector3(0f, 0f, 0), transform.rotation);
        //this.enabled = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
