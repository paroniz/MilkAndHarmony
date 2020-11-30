using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juokse2 : MonoBehaviour {
    
    public float nopeus;
    public float hyppyvoima;
    public float luotinopeus = 80f;
    public AudioClip laukaus;
    private AudioSource audio;
    private int suunta = 1;
    private Animator ani = null;
    private bool saaampua = true;
    private bool ammuscooldown = false;
    private bool hyokkaa = false;
    public float ammussekunnit;

    float horizontal;

    public Rigidbody2D luoti;
    public GameObject piipputuli;

public float speed=100;
    Rigidbody2D rb; 

    void Start() {
        rb = GetComponent<Rigidbody2D>(); 
        this.ani = this.GetComponent<Animator>();

        audio = gameObject.AddComponent<AudioSource>(); 
        audio.clip = laukaus;
        audio.volume = 0.15f;
    }
     
    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
       
        float moveBy = horizontal * speed; 
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
        Vector3 suunta = LaskeSuunta();
        transform.Translate(suunta * nopeus * Time.deltaTime);

        if((horizontal > 0) && (this.suunta != 1))
        {
            this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
            this.suunta = 1;
        }

        if((horizontal < 0) && (this.suunta != 2))
        {
            this.GetComponent<Transform>().Rotate(0f,180f, 0f);
            this.suunta = 2;
        }

        if((Input.GetButtonDown("Jump")  && (this.GetComponent<Rigidbody2D>().velocity.y == 0)))
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * hyppyvoima);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            // if(saaampua == true)
            // {
                
                    
            //         this.ani.SetTrigger("Attack");
         
        
            //         hyokkaa = true;   
            //     Melee();
            //     audio.Play();
            //     saaampua = false;
            //     ammuscooldown = true;
            //     ammussekunnit = 0.6f;
                
            // }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.ani.SetInteger("kingmovement", 1);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.ani.SetInteger("kingmovement", 1);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.ani.SetInteger("kingmovement", 0);
        }
        
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.ani.SetInteger("kingmovement", 0);
        }
        
        ammussekunnit -= Time.deltaTime;
        if (ammussekunnit <= 0f && ammuscooldown == true) 
        {  
            saaampua = true; 
            ammuscooldown = false;
        }
    }

    public Vector3 LaskeSuunta()
    {
        Vector3 suunta = Vector3.zero;
            
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            suunta.x += 1.0f;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            suunta.x += 1.0f;
        }
        return suunta.normalized;
    }

    void Melee()
    {

    }
}
