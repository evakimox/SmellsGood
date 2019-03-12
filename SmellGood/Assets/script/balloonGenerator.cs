using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonGenerator : MonoBehaviour {

    int interval;
    int timer;
    public GameObject balloon;
    public GameObject tutorialBalloon;

	// Use this for initialization
	void Start () {
        interval = 200;
        timer = 0;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        GameObject balloonToGenerate;
        if (Random.Range(0f, 16f) > 10) {
            balloonToGenerate = tutorialBalloon;
        }
        else
        {
            balloonToGenerate = balloon;
        }

        if (timer <= 0) {
            timer = interval;
            GameObject generatedBalloon = Instantiate(balloonToGenerate);
            Vector3 balloonPos = transform.position;
            balloonPos.x = balloonPos.x - 8f + Random.Range(0f,16f);
            balloonPos.y = -6f;
            generatedBalloon.transform.position = balloonPos;
            Vector3 balloonVelo = generatedBalloon.GetComponent<Rigidbody2D>().velocity;
            balloonVelo.y = 2f;
            generatedBalloon.GetComponent<Rigidbody2D>().velocity = balloonVelo;
        }
        timer--;
    }
}
