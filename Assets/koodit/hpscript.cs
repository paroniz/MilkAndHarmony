using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hpscript: MonoBehaviour 
{
    public Animator animator;
    public AudioClip deathsound;
    public GameObject kuolinani;
    public GameObject heartz3;
    public GameObject heartz2;
    private GameObject heart3;
    private GameObject heart2;
    private GameObject heart1;
    private GameObject vaihdasydan;
    private GameObject holderi;
    private GameObject holderi2;
    private GameObject kamera;
    private AudioSource audio;
    private bool osunut;
    private bool bombhit = false;
    private bool tippunut;
    private bool kuollut = false;
    private bool tuhottu1 = false;
    private bool tuhottu2 = false;
    private float iskutime;  
    private int hp = 3; 
    Rigidbody2D rb;
    Vector2 knockbackVectorLeft;
    Vector2 knockbackVectorRight;
    Vector2 enemyDirection;

    void Start() {
        knockbackVectorLeft = new Vector2(1,1);
        knockbackVectorRight = new Vector2(-1,1);
        rb = gameObject.GetComponent<Rigidbody2D>();
        audio = gameObject.AddComponent<AudioSource>(); 
        audio.clip = deathsound;
        audio.volume = 1.0f;
        heart1 =  GameObject.Find("SmallHeart1");
        heart2 =  GameObject.Find("SmallHeart2");
        heart3 =  GameObject.Find("SmallHeart3");
        kamera =  GameObject.Find("Main Camera");
        Physics2D.IgnoreLayerCollision(11, 12, false);
    }

    void Update() 
    {
        if(this.transform.position.y < -6.5f && !tippunut)
        {
            tippunut = true;
            hp--;
            audio.Play();
            if (hp > 0) 
            {
            this.transform.position = new Vector2(-7.48f, -0.31f);
            kamera.transform.position = new Vector3(0, 0, -10);
            tippunut = false;
            }
        }

        iskutime -= Time.deltaTime;
        if (iskutime <= 0f) 
        {   
            osunut = false;
        }

        if (hp <= 0 && !kuollut)
        {
            kuollut = true;
            //StartCoroutine(kuolema());
            Destroy(heart1);
        }

        if (hp < 3 && !tuhottu1)
        {
            tuhottu1 = true;
            //GameObject vaihdasydan = Instantiate(heartz3, kamera.transform.position + new Vector3(-7.23f, 4.05f, 11f), transform.rotation);
            //vaihdasydan.transform.parent = kamera.transform;
            //holderi = vaihdasydan;
            Destroy(heart3);
            Debug.Log("thoaa");
            //animator.SetTrigger("Destroy");
        }
    
        if (hp < 2 && !tuhottu2)
        {
            tuhottu2 = true;
            //GameObject vaihdasydan2 = Instantiate(heartz2, kamera.transform.position + new Vector3(-7.931f, 4.05f, 11f), transform.rotation);
           // vaihdasydan2.transform.parent = kamera.transform;
            //holderi2 = vaihdasydan2;
            Destroy(holderi);
            Destroy(heart2);
        }
    }   

    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.collider.tag == "Enemy" && !osunut))
        {
            enemyDirection = collision.transform.position - transform.position;
            Debug.Log(enemyDirection.x);

            if(enemyDirection.x > 0)
            {
                knockbackLeft();
            }
            else
            {
                knockbackRight();
            }
            
            audio.Play();
            osunut = true;
            iskutime = 1.5f;
            hp--;
        }

        if(collision.gameObject.name == "BigHeart")
        {
            hp++;
            Debug.Log("yolo3");
        }
        
        if((collision.collider.tag == "Bomb" && !osunut && !bombhit))
        {
            bombhit = true;
            audio.Play();
            osunut = true;
            iskutime = 1.5f;
            hp--;

            if(enemyDirection.x > 0)
            {
                knockbackLeft();
            }
            else
            {
                knockbackRight();
            }
            
            StartCoroutine(bombhittime());
            bombhit = false;
        }
        
        if (collision.gameObject.layer == 11)
        {
            Physics2D.IgnoreLayerCollision(11, 12, true); 
            StartCoroutine("colliderreturnwait");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if((collision.collider.tag == "Enemy" && !osunut))
        {
            enemyDirection = collision.transform.position - transform.position;
            Debug.Log(enemyDirection.x);

            if(enemyDirection.x > 0)
            {
                knockbackLeft();
            }
            else
            {
                knockbackRight();
            }
            
            audio.Play();
            osunut = true;
            iskutime = 1.5f;
            hp--;
        }

        if(collision.gameObject.name == "BigHeart")
        {
            hp++;
            Debug.Log("yolo3");
        }
        
        if((collision.collider.tag == "Bomb" && !osunut && !bombhit))
        {
            bombhit = true;
            audio.Play();
            osunut = true;
            iskutime = 1.5f;
            hp--;

            if(enemyDirection.x > 0)
            {
                knockbackLeft();
            }
            else
            {
                knockbackRight();
            }
            
            StartCoroutine(bombhittime());
            bombhit = false;
        }
        
        if (collision.gameObject.layer == 11)
        {
            Physics2D.IgnoreLayerCollision(11, 12, true); 
            StartCoroutine("colliderreturnwait");
        }
    }

    private void knockbackRight()
    {
        rb.AddForce(knockbackVectorLeft * 500);
        Debug.Log("knockbackingright");
    }

    private void knockbackLeft()
    {
        rb.AddForce(knockbackVectorRight * 500);
        Debug.Log("knockbacking");
    }

    IEnumerator colliderreturnwait()
    {
        yield return new WaitForSeconds(1.5f);
        Physics2D.IgnoreLayerCollision(11, 12, false); 
    }

    IEnumerator kuolema()
    {
        Destroy(holderi2);
        GameObject kuolinanimaatio = Instantiate(kuolinani, transform.position, transform.rotation);
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene("tappioskene");
    }   
    IEnumerator bombhittime()
    {
        yield return new WaitForSeconds(1.6f);
    }   
}
