using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour {
    private Vector3 initLocalScale;
    private bool ableToJump;

    //public static mainScript instance;
    private void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        initLocalScale = transform.localScale;
        ableToJump = false;
    }

    public Vector3 getMainPosition()
    {
        return transform.position;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(Input.GetKey("left shift") || Input.GetKey("right shift")) { 
            // shouldn't move character
        }
        else {
            if(GetComponent<Rigidbody2D>().gravityScale > 0.5f)
            {
                movementControl();
            }

        }
    }

    private void movementControl()
    {
        if (Input.GetKey("left"))
        {
            transform.localScale = initLocalScale;
            Vector3 curPos = transform.position;
            curPos.x = curPos.x - 0.1f;
            GetComponent<Animator>().SetFloat("hspeed", 1f);
            transform.position = curPos;
        }
        if (Input.GetKey("right"))
        {
            Vector3 flipScale = initLocalScale;
            flipScale.x = -flipScale.x;
            transform.localScale = flipScale;
            Vector3 curPos = transform.position;
            curPos.x = curPos.x + 0.1f;
            GetComponent<Animator>().SetFloat("hspeed", 1f);
            transform.position = curPos;
        }
        if (Input.GetKeyDown("up"))
        {
            if (ableToJump)
            {
                Vector3 velocity = GetComponent<Rigidbody2D>().velocity;
                velocity.y = 5f;
                GetComponent<Rigidbody2D>().velocity = velocity;
                ableToJump = false;
            }
        }
        if (Input.GetKeyUp("left") || Input.GetKeyUp("right"))
        {
            GetComponent<Animator>().SetFloat("hspeed", 0f);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "floor")
        {
            ableToJump = true;
        }
    }
}
