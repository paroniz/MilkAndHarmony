using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vihollinen : MonoBehaviour
{
    public Animator animator;
    public GameObject coin2;
    public int maxHealth = 100;
    public int goldCount = 50;
    int currentHealth;
    private AudioSource audio;
    public AudioClip gettingHit;
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
            StartCoroutine(destroythis());
        }
    }

    IEnumerator destroythis()
    {
        Debug.Log("Enemy died!");
        //animator.SetTrigger("CannonShot");
        animator.SetBool("IsDead", true);
        
        GetComponent<Collider2D>().enabled = false;
        GameObject coin = Instantiate(coin2, transform.position + new Vector3(0f, 0f, 0), transform.rotation);
        //this.enabled = false;
        yield return new WaitForSeconds(1f);
        
        Destroy(gameObject);
    }
}
