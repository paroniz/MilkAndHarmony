using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracode : MonoBehaviour {
    
    public GameObject player;
    void Start() {}

    void Update() {
        Vector3 setPosition = transform.position;
        setPosition.x = player.transform.position.x;

        if(player.transform.position.x > 0 && player.transform.position.x < 266.5)
        {
            this.transform.position = setPosition;
        }
    }
}

