using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonballscript : MonoBehaviour
{
    private Animator ani = null;
    public float explowait = 0.5f;
    void Start()
    {
        this.ani = this.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ani.SetTrigger("Explo");
        StartCoroutine(explo());
    }

    IEnumerator explo()
    {
        yield return new WaitForSeconds(explowait);
        Destroy(gameObject);
    }
}
