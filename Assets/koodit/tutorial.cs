using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    GameObject king;
    public GameObject note;
    public GameObject swingnote;
    public float jumpguideposition = 4.5f;
    public float swingguideposition = 4.5f;
    public bool called;
    public bool swingcalled;
    public bool cancelled = true;
    public bool swingcancelled = true;


    void Start()
    {
        king = GameObject.Find("King");
        //note = GameObject.Find("TutorialCanvasJump");
        called = false;
        swingcalled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(king.transform.position.x > jumpguideposition && called == false)
        {
            note.SetActive(true);
            called = true;
            cancelled = false;
        }

        if(cancelled == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                note.SetActive(false);
                cancelled = true;
            }
        }

        if(king.transform.position.x > swingguideposition && swingcalled == false)
        {
            swingnote.SetActive(true);
            swingcalled = true;
            swingcancelled = false;
        }

        if(swingcancelled == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                swingnote.SetActive(false);
                swingcancelled = true;
            }
        }
    }
}
