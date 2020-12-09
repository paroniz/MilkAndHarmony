using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonballscript : MonoBehaviour
{
    private Animator ani = null;
    void Start()
    {
        this.ani = this.GetComponent<Animator>();
        ani.SetTrigger("Explo");
    }

    void Update()
    {
        
    }

    // void OnCollisionStay2D(Collision2D collision)
    //  {
    //     //  if((collision.collider.tag == "Bomb" && !osunut && !bombhit))
    //     // {
    //     //     bombhit = true;
    //     //     audio.Play();
    //     //     osunut = true;
    //     //     iskutime = 1.5f;
    //     //     hp--;
    //     //     StartCoroutine(bombhittime());
    //     //     bombhit = false;
    //     // }
    //  }
}
