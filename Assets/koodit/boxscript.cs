using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxscript : MonoBehaviour
{ 
    public Animator animator;
    public int maxHealth = 40;

    public float boxdestrowait = 0.3f;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if(currentHealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        //animator.SetTrigger("CannonShot");
        animator.SetTrigger("Broke");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        StartCoroutine("Destroy");   
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(boxdestrowait);
        Destroy(gameObject);
    }
}
