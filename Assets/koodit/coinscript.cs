using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class coinscript : MonoBehaviour
{
    public int score;
    private string rahamaara;
    private int rahamaara2;
    private GameObject showgold = null;
    private Animator ani = null;
    void Start()
    {
        this.ani = this.GetComponent<Animator>();
        showgold = GameObject.Find("GoldCount");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "King")
        {
            rahamaara = showgold.GetComponent<Text>().text;
            rahamaara2 = System.Convert.ToInt32(rahamaara);
            rahamaara2 += score;
            rahamaara = rahamaara2.ToString();
            ani.SetTrigger("Destroy");
            showgold.GetComponent<Text>().text = rahamaara;
            //audio.Play();
            //osunut = true;
            //iskutime = 1.5f;
            //hp--;
            //Debug.Log("yolo3");
            StartCoroutine(destro());
        }
    }

    IEnumerator destro()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
