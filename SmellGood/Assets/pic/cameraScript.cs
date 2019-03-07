using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("left"))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x - 0.1f;
            transform.position = pos;
        }
        if (Input.GetKey("right"))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + 0.1f;
            transform.position = pos;
        }
    }
}
