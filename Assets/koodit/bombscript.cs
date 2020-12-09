using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombscript : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator.SetTrigger("Bombon");
        StartCoroutine(changetag());
        StartCoroutine(explo());
    }

    IEnumerator explo()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    

    IEnumerator changetag()
    {
        yield return new WaitForSeconds(2f);
        transform.gameObject.tag = "Bomb"; 
        Debug.Log("testest");
    }
}
