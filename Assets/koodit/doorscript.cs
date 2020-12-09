using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorscript : MonoBehaviour
{
    //public AudioClip voittoaani;
    public string roomnumber; 
    //private AudioSource voitto;
    private Animator ani = null;
    public Animator king;
    //private bool hit = false;
    float vertical;

    void Start() 
    {
        this.ani = this.GetComponent<Animator>();
        //voitto = gameObject.AddComponent<AudioSource>(); 
        //voitto.clip = voittoaani;
        //voitto.volume = 0.3f;
    }

    void Update() 
    {
        vertical = Input.GetAxisRaw("Vertical");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("uolo");
            StartCoroutine(changescene());  
        }
    }

    IEnumerator changescene()
    {
        king.SetTrigger("doorin");
        // voitto.Play();
        // this.ani.SetBool("avaus", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("scene" + roomnumber);
    } 
}

