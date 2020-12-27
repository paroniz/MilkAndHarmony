using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject note;
    public GameObject swingNote;
    private GameObject king;
    public float jumpNotePosition = 4.5f;
    public float swingNotePosition= 4.5f;
    public bool called;
    public bool swingCalled;
    public bool cancelled = true;
    public bool swingCancelled = true;

    void Start()
    {
        king = GameObject.Find("King");
        called = false;
        swingCalled = false;
    }

    void Update()
    {
        if(king.transform.position.x > jumpNotePosition && called == false)
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

        if(king.transform.position.x > swingNotePosition && swingCalled == false)
        {
            swingNote.SetActive(true);
            swingCalled = true;
            swingCancelled = false;
        }

        if(swingCancelled == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                swingNote.SetActive(false);
                swingCancelled = true;
            }
        }
    }
}
