using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterikoodi2 : MonoBehaviour {
    
    public AudioClip tappoaani;
    public AudioClip kuolinaani;
    public GameObject kuolinani;
    private AudioSource tappohuuto;
    private AudioSource kuolinhuuto;
    public float nopeus;
    public float etaisyys;
    public float etaisyys2;
    public int hp;
    private float huutocountdown;
    private bool osunut;
    private bool kuollut = false;
    
    void Start() {
        tappohuuto = gameObject.AddComponent<AudioSource>(); 
        tappohuuto.clip = tappoaani;
        tappohuuto.volume = 0.8f;
        kuolinhuuto = gameObject.AddComponent<AudioSource>(); 
        kuolinhuuto.clip = kuolinaani;
        kuolinhuuto.volume = 0.4f;
    }

    void Update() {
        
        if (!kuollut){
            this.GetComponent<Transform>().Translate(nopeus * Time.deltaTime, 0f, 0f);
        }

        if (this.GetComponent<Transform>().position.x < etaisyys)
        {    
            this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
        }

        if (this.GetComponent<Transform>().position.x > etaisyys2)
        {    
            this.GetComponent<Transform>().Rotate(0f, 180f, 0f);
        }

        if (hp == 0 && !kuollut)
        {   
            kuollut = true;
            StartCoroutine(kuolema());
        }

        huutocountdown -= Time.deltaTime;
        if (huutocountdown <= 0f) 
        {   
            osunut = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "luoti")
        {
            hp--;
        }
        
        if(collision.collider.tag == "hero" && !osunut)
        {
            tappohuuto.Play();
            osunut = true;
            huutocountdown = 1.5f;
        }
    }

    IEnumerator kuolema()
    {
        transform.gameObject.tag = "kuollutmonsu"; 
        kuolinhuuto.Play();
        GameObject kuolinanimaatio = Instantiate(kuolinani, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject); 
    } 
}