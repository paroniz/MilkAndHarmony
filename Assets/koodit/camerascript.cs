using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour 
{
    public GameObject player;

    public float cameraheight = 1.8f;
    
    void Update() 
    {
        Vector3 setPosition = transform.position;
        setPosition.x = player.transform.position.x;
        setPosition.y = player.transform.position.y + cameraheight;

        //if(player.transform.position.x > 0 && player.transform.position.x < 266.5)
       // {
            this.transform.position = setPosition;
       // }
    }
}

