using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raiseFloor : MonoBehaviour {

    float speed;

	// Use this for initialization
	void Start () {
        speed = 0.5f;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setSpeed(float v) {
        speed = v;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "goal")
        {
            speed = 0f;
        }

        if (collision.collider.gameObject.tag == "main")
        {
            Vector3 velo =
            GetComponent<Rigidbody2D>().velocity;
            velo.y = speed;
            GetComponent<Rigidbody2D>().velocity = velo;
        }


    }
}
