using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonSelf : MonoBehaviour {

    int existTime;

	// Use this for initialization
	void Start () {
        existTime = 0;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        existTime++;

        if(existTime > 1000) {
            Destroy(this.gameObject);
        }

    }
}
