using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public Animator king;
    private Animator ani = null;
    public string roomNumber; 

    void Start() 
    {
        this.ani = this.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(ChangeScene());  
        }
    }

    IEnumerator ChangeScene()
    {
        king.SetTrigger("doorin");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("scene" + roomNumber);
    } 
}

