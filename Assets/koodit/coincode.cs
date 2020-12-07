using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class coincode : MonoBehaviour
{

    public int score;

    private string rahamaara;
    private int rahamaara2;

    private GameObject showgold = null;
    // Start is called before the first frame update
    void Start()
    {
        showgold = GameObject.Find("GoldCount");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "King")
        {
            rahamaara = showgold.GetComponent<Text>().text;
            rahamaara2 = System.Convert.ToInt32(rahamaara);
            rahamaara2 += score;
            rahamaara = rahamaara2.ToString();
            showgold.GetComponent<Text>().text = rahamaara;
            //audio.Play();
            //osunut = true;
            //iskutime = 1.5f;
            //hp--;
            Debug.Log("yolo3");
            Destroy(gameObject);
        }

    }

}
