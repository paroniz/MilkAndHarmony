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
    // Start is called before the first frame update
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
            StartCoroutine(destroythis());
        }
    }

    IEnumerator destroythis()
    {
        Debug.Log("Enemy died!");
        animator.SetTrigger("CannonShot");
        animator.SetBool("IsDead", true);
        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        yield return new WaitForSeconds(1f);
        GameObject coin = Instantiate(coin2, transform.position + new Vector3(0f, 0f, 0), transform.rotation);
        Destroy(gameObject);
    }
}
