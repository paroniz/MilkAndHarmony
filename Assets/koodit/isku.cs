using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isku : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        float jAxis = Input.GetAxis("Fire1");
        
        if (Time.time >= nextAttackTime)
        {
            if (jAxis > 0f)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


    foreach(Collider2D enemy in hitEnemies)
    {
        enemy.GetComponent<vihollinen>().TakeDamage(attackDamage);
    }
    }


private void OnDrawGizmosSelected()
{
    if (attackPoint==null)
    return;

    Gizmos.DrawWireSphere(attackPoint.position, attackRange);   
}
}