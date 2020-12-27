using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kingMove2 : MonoBehaviour {
    
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

    public bool onGround = false;

    float horizontal;

    public Rigidbody2D luoti;
    public GameObject piipputuli;

    public Vector3 colliderOffset;

    public float groundLength = 0.6f;

    public LayerMask groundLayer;
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
        
        
       
        // float moveBy = horizontal * speed; 
        // rb.velocity = new Vector2(moveBy, rb.velocity.y); 
        Vector3 suunta = LaskeSuunta();
        transform.Translate(suunta * nopeus * Time.deltaTime);
        //rb.MovePosition(transform.position + (suunta * nopeus * Time.deltaTime));
        horizontal = Input.GetAxisRaw("Horizontal");
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
        //onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

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

        if((Input.GetButtonDown("Jump")  && onGround))
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * hyppyvoima);
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

    
    void FixedUpdate()
    {
        
    }
    

    public Vector3 LaskeSuunta()
    {
        Vector3 suunta = Vector3.zero;
            
        if (horizontal > 0)
        {
            suunta.x += 1.0f;
        }
        
        if (horizontal < 0)
        {
            suunta.x += 1.0f;
        }
        return suunta.normalized;
    }

    void Melee()
    {

    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }
}
