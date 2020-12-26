using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isku : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask boxLayers;
    private AudioSource audio;
    public AudioClip hammerSwing;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

 
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>(); 
        audio.clip = hammerSwing;
        audio.volume = 1.0f;
    }

    void Update()
    {
        float fireaxis = Input.GetAxis("Fire1");
        
        if (Time.time >= nextAttackTime)
        {
            if (fireaxis > 0f)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        audio.Play();
        
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        Collider2D[] hitBoxes = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, boxLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.tag == "Enemy")
            {
                enemy.GetComponent<vihollinen>().TakeDamage(attackDamage);
                Debug.Log("enemytakeshit");
            }
        }
    
        foreach(Collider2D box in hitBoxes)
        {
            if (box.gameObject.tag == "Box")
            {
                box.GetComponent<boxscript>().TakeDamage(attackDamage);
                Debug.Log("boxtakeshit");
            }
       }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint==null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);   
    }
}