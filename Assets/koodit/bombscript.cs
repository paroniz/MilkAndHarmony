using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombscript : MonoBehaviour
{

    public Animator animator;
    public float explowait = 4f;
    public float changetagwait = 2f;
    void Start()
    {
        animator.SetTrigger("Bombon");
        //StartCoroutine(changetag());
        StartCoroutine(explo());
    }

    IEnumerator explo()
    {
        yield return new WaitForSeconds(explowait);
        Destroy(gameObject);
    }
    

    IEnumerator changetag()
    {
        yield return new WaitForSeconds(changetagwait);
        transform.gameObject.tag = "Bomb"; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Explo");
    }
}
