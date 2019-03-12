using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    private float cameraBoundary;
    public static cameraScript instance;
    public GameObject jitui;
    private Vector3 initPosition;
    public GameObject mainChar;

    // Use this for initialization
    void Awake () {
        cameraBoundary = 9;
        initPosition = transform.position;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
            cameraMovingListener();
        }
        /*
        if(Input.GetKeyUp("left shift") || Input.GetKeyUp("right shift"))
        {
            Vector3 backTo = transform.position;
            backTo.x = initPosition.x;
            backTo.y = initPosition.y;
            transform.position = backTo;
        }
        */
        if(transform.position.x <= -3f)
        {
            jitui.gameObject.GetComponent<smellScript>().seen = true;
        }

        followMain();

    }

    void followMain() {
        Vector3 mainPos = mainChar.gameObject.transform.position;
        while((mainPos.x - transform.position.x) > 8f) 
        {
            //main is at right
            Vector3 cameraPos = transform.position;
            cameraPos.x = cameraPos.x + 0.05f;
            transform.position = cameraPos;
        }
        while ((mainPos.x - transform.position.x) < -8f)
        {
            //main is at left
            Vector3 cameraPos = transform.position;
            cameraPos.x = cameraPos.x - 0.05f;
            transform.position = cameraPos;
        }

        while ((mainPos.y - transform.position.y) > 4f)
        {
            //main is at top
            Vector3 cameraPos = transform.position;
            cameraPos.y = cameraPos.y + 0.05f;
            transform.position = cameraPos;
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
    }

    public Vector3 getCameraPosition() 
    {
        return transform.position;
    }
}
