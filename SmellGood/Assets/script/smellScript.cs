using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smellScript : MonoBehaviour {

    public GameObject lineHolder;
    public GameObject mainChar;
    public GameObject mainPlane;

    private GameObject realLineHolder;
    public Vector3[] vertexPos;
    public bool seen;

    bool smelled;
    bool startMove;
    bool finishedMoving;
    float totalZ;
    float totalX;
    float totalY;

	// Use this for initialization
	void Start () {
        smelled = false;
        startMove = false;
        finishedMoving = false;
        realLineHolder = Instantiate(lineHolder);
        LineRenderer lineRenderer = lineHolder.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 5;
        lineRenderer.startWidth = 0.3f;
        lineRenderer.endWidth = 0.3f;
        lineRenderer.sortingOrder = 4;
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (!finishedMoving)
        {
            renderSmell();
        }

        if (Input.GetKeyDown("s") && !smelled) {
            startMove = true;
        }
        if (startMove)
        {
            moveMainCharactor();
        }
    }
    
    public void renderSmell() {
        LineRenderer lineRenderer = realLineHolder.GetComponent<LineRenderer>();
        if (seen)
        {
            vertexPos = new Vector3[5];
            Vector3 mainPos = mainChar.gameObject.GetComponent<mainScript>().getMainPosition();
            Vector3 midPoint1 = (transform.position - mainPos) / 4 + mainPos;
            Vector3 midPoint2 = (transform.position - mainPos) / 2 + mainPos;
            Vector3 midPoint3 = 3 * (transform.position - mainPos) / 4 + mainPos;
            midPoint2.y = midPoint2.y + 3f;
            midPoint1.y = midPoint1.y + 2.2f;
            midPoint3.y = midPoint3.y + 2.2f;

            vertexPos[0] = mainPos;
            vertexPos[4] = transform.position;
            vertexPos[1] = midPoint1;
            vertexPos[2] = midPoint2;
            vertexPos[3] = midPoint3;

            lineRenderer.startColor = new Color(1f, 1f, 1f, 0.5f);
            lineRenderer.endColor = new Color(1f, 1f, 1f, 0.5f);
            lineRenderer.SetPositions(vertexPos);
        }
        else {
            //do not show line
            lineRenderer.startColor = new Color(1f, 1f, 1f, 0f);
            lineRenderer.endColor = new Color(1f, 1f, 1f, 0f);
        }
    }

    void moveMainCharactor()
    {

        float param = 200;
        if (seen) {
            Vector3 planePos = mainPlane.gameObject.transform.position;
            Vector3 mainPos = mainChar.gameObject.transform.position;

            if (!smelled)
            {
                totalX = transform.position.x - mainPos.x;
                totalY = transform.position.y - mainPos.y;
                totalZ = transform.position.z - planePos.z;
                smelled = true;

                mainChar.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }

            if (Mathf.Abs(planePos.z - transform.position.z) > 0.1)
            {
                planePos.z = totalZ/param + planePos.z;
                mainPlane.gameObject.transform.position = planePos;
            }
            if (Mathf.Abs(mainPos.x - transform.position.x) > 0.1 ||
                Mathf.Abs(mainPos.y - transform.position.y) > 0.1
                )
            {
                mainPos.x = totalX/param + mainPos.x;
                mainPos.y = totalY/param + mainPos.y;
                mainPos.z = planePos.z;
                mainChar.gameObject.transform.position = mainPos;
            }
            else {
                mainChar.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                Destroy(realLineHolder);
                startMove = false;
                finishedMoving = true;
            }
        }
    }

}
