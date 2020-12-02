using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diamondcode : MonoBehaviour
{

    private Animator ani = null;
    // Start is called before the first frame update
    void Start()
    {
        this.ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
void OnTriggerEnter2D(Collider2D collision){

           if(collision.gameObject.name == "King")
           {
          
        
          
          StartCoroutine(destroythis());
          }}

          IEnumerator destroythis(){
              //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
              Debug.Log("yolo");
              ani.SetTrigger("Destroy");
                yield return new WaitForSeconds(1f);
                Destroy(gameObject);
                
          }
}
