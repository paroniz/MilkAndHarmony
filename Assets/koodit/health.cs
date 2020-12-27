using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour 
{
    public Animator animator;
    public AudioClip die;
    public AudioClip takingHit;
    public GameObject deathAni;
    public GameObject heartz3;
    public GameObject heartz2;
    private GameObject heart3;
    private GameObject heart2;
    private GameObject heart1;
    private GameObject changeHeart;
    private GameObject holder;
    private GameObject holder2;
    private GameObject camera;
    private AudioSource audio;
    private AudioSource audioDie;
    private Rigidbody2D rb;
    private Vector2 knockbackVectorLeft;
    private Vector2 knockbackVectorRight;
    private Vector2 enemyDirection;
    private bool hit;
    private bool bombHit = false;
    private bool fallen;
    private bool dead = false;
    private bool eliminated1 = false;
    private bool eliminated2 = false;
    private float hitTime;  
    private int hp = 3; 
    
    void Start() 
    {
        knockbackVectorLeft = new Vector2(1,1);
        knockbackVectorRight = new Vector2(-1,1);
        rb = gameObject.GetComponent<Rigidbody2D>();
        audio = gameObject.AddComponent<AudioSource>(); 
        audio.clip = takingHit;
        audio.volume = 1.0f;
        audioDie = gameObject.AddComponent<AudioSource>(); 
        audioDie.clip = die;
        audioDie.volume = 1.0f;
        heart1 =  GameObject.Find("SmallHeart1");
        heart2 =  GameObject.Find("SmallHeart2");
        heart3 =  GameObject.Find("SmallHeart3");
        camera =  GameObject.Find("Main Camera");
        Physics2D.IgnoreLayerCollision(11, 12, false);
    }

    void Update() 
    {
        if(this.transform.position.y < -6.5f && !fallen)
        {
            fallen = true;
            hp--;
            
            if (hp > 0) 
            {
            this.transform.position = new Vector2(-7.48f, -0.31f);
            camera.transform.position = new Vector3(0, 0, -10);
            fallen = false;
            }
        }

        hitTime -= Time.deltaTime;
        if (hitTime <= 0f) 
        {   
            hit = false;
        }

        if (hp <= 0 && !dead)
        {
            dead = true;
            audioDie.Play();
            //StartCoroutine(Death());
            Destroy(heart1);
        }

        if (hp < 3 && !eliminated1)
        {
            eliminated1 = true;
            //GameObject changeHeart = Instantiate(heartz3, camera.transform.position + new Vector3(-7.23f, 4.05f, 11f), transform.rotation);
            //changeHeart.transform.parent = camera.transform;
            //holder = changeHeart;
            Destroy(heart3);
            //Debug.Log("thoaa");
            //animator.SetTrigger("Destroy");
        }
    
        if (hp < 2 && !eliminated2)
        {
            eliminated2 = true;
            //GameObject changeHeart2 = Instantiate(heartz2, camera.transform.position + new Vector3(-7.931f, 4.05f, 11f), transform.rotation);
           // changeHeart2.transform.parent = camera.transform;
            //holder2 = changeHeart2;
            Destroy(holder);
            Destroy(heart2);
        }
    }   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.collider.tag == "Enemy" && !hit))
        {
            enemyDirection = collision.transform.position - transform.position;
            Debug.Log(enemyDirection.x);

            if(enemyDirection.x > 0)
            {
                KnockbackLeft();
            }
            else
            {
                KnockbackRight();
            }
            
            audio.Play();
            hit = true;
            hitTime = 1.5f;
            hp--;
        }

        if(collision.collider.tag == "Spikes")
        {
 
            audio.Play();
            hit = true;
            //hitTime = 1.5f;
            hp = 0;
        }

        if(collision.gameObject.name == "BigHeart")
        {
            hp++;
            Debug.Log("yolo3");
        }
        
        if((collision.collider.tag == "Bomb" && !hit && !bombHit))
        {
            bombHit = true;
            audio.Play();
            hit = true;
            hitTime = 1.5f;
            hp--;

            if(enemyDirection.x > 0)
            {
                KnockbackLeft();
            }
            else
            {
                KnockbackRight();
            }
            
            StartCoroutine(BombHitTime());
            bombHit = false;
        }
        
        if (collision.gameObject.layer == 11)
        {
            Physics2D.IgnoreLayerCollision(11, 12, true); 
            StartCoroutine("ColliderReturnWait");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if((collision.collider.tag == "Enemy" && !hit))
        {
            enemyDirection = collision.transform.position - transform.position;
            Debug.Log(enemyDirection.x);

            if(enemyDirection.x > 0)
            {
                KnockbackLeft();
            }
            else
            {
                KnockbackRight();
            }
            
            audio.Play();
            hit = true;
            hitTime = 1.5f;
            hp--;
        }

        if(collision.gameObject.name == "BigHeart")
        {
            hp++;
            Debug.Log("yolo3");
        }
        
        if((collision.collider.tag == "Bomb" && !hit && !bombHit))
        {
            bombHit = true;
            audio.Play();
            hit = true;
            hitTime = 1.5f;
            hp--;

            if(enemyDirection.x > 0)
            {
                KnockbackLeft();
            }
            else
            {
                KnockbackRight();
            }
            
            StartCoroutine(BombHitTime());
            bombHit = false;
        }
        
        if (collision.gameObject.layer == 11)
        {
            Physics2D.IgnoreLayerCollision(11, 12, true); 
            StartCoroutine("ColliderReturnWait");
        }
    }

    private void KnockbackRight()
    {
        rb.AddForce(knockbackVectorLeft * 500);
    }

    private void KnockbackLeft()
    {
        rb.AddForce(knockbackVectorRight * 500);
    }

    IEnumerator ColliderReturnWait()
    {
        yield return new WaitForSeconds(1.5f);
        Physics2D.IgnoreLayerCollision(11, 12, false); 
    }

    IEnumerator Death()
    {
        Destroy(holder2);
        animator.SetTrigger("death");
        //GameObject deathAnimaatio = Instantiate(deathAni, transform.position, transform.rotation);
        //GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene("GameOver");
    }   
    IEnumerator BombHitTime()
    {
        yield return new WaitForSeconds(1.6f);
    }   
}
