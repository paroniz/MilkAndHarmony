using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpaddscript : MonoBehaviour

{

    private Animator ani = null;
    // Start is called before the first frame update private Animator ani = null;
    // Start is called before the first frame update
    void Start()
    {
        this.ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
void OnCollisionEnter2D(Collision2D collision){

           if(collision.gameObject.name == "King")
           {
          
        
          
          StartCoroutine(destroythis());
          }}

          IEnumerator destroythis(){
              gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
              ani.SetTrigger("Destroy");
                yield return new WaitForSeconds(1f);
                Destroy(gameObject);
                
          }
}
