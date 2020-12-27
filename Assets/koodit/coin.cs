using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class coin : MonoBehaviour
{
    public int score;
    private string moneyText;
    private int amount;
    private GameObject moneyUI = null;
    private Animator ani = null;
    public AudioClip coinSound;
    private AudioSource audio;
    
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>(); 
        audio.clip = coinSound;
        audio.volume = 0.4f;
        this.ani = this.GetComponent<Animator>();
        moneyUI = GameObject.Find("GoldCount");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "King")
        {
            moneyText = moneyUI.GetComponent<Text>().text;
            amount = System.Convert.ToInt32(moneyText);
            amount += score;
            moneyText = amount.ToString();
            ani.SetTrigger("Destroy");
            moneyUI.GetComponent<Text>().text = moneyText;
            audio.Play();
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
