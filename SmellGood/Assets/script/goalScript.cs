using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalScript : MonoBehaviour {
    public Text winText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "main") {
            winText.text = "You win!";
        }
        if(other.gameObject.tag == "floor") {
            Vector3 veloFloor = other.gameObject.GetComponent<Rigidbody2D>().velocity;
            veloFloor.y = 0f;
            other.gameObject.GetComponent<raiseFloor>().setSpeed(0);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = veloFloor;
        }
    }
}
