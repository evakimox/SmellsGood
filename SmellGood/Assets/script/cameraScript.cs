using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    private float cameraBoundary;

	// Use this for initialization
	void Start () {
        cameraBoundary = 9;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
            cameraMovingListener();
        }

    }

    void cameraMovingListener() 
    {
        if (Input.GetKey("right"))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x - 0.1f;
            if (Mathf.Abs(pos.x) < cameraBoundary)
            {
                transform.position = pos;
            }
        }
        if (Input.GetKey("left"))
        {
            Vector3 pos = transform.position;
            pos.x = pos.x + 0.1f;
            if (Mathf.Abs(pos.x) < cameraBoundary)
            {
                transform.position = pos;
            }
        }
        if (Input.GetKey("up"))
        {
            Vector3 pos = transform.position;
            pos.z = pos.z + 0.1f;
            if (Mathf.Abs(pos.x) < cameraBoundary)
            {
                transform.position = pos;
            }
        }
    }
}
