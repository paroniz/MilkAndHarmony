using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpaddscript : MonoBehaviour
{
    private Animator ani = null;
    
    void Start()
    {
        this.ani = this.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "King")
        {
            StartCoroutine(destroythis());
        }
    }

    IEnumerator destroythis()
    {
        //gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        ani.SetTrigger("Destroy");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);            
    }
}
