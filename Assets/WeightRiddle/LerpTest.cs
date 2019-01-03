using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour {

    public GameObject sack;
    public float distance;
    private Vector3 startPos;
    private Vector3 endPos;

    private float lerpTime = 2.5f;
    private float currentLerpTime;

	void Start () {
        startPos = sack.transform.position;
        endPos = sack.transform.position + Vector3.down * distance;
	}
	
	// Update is called once per frame
	void Update () {
        currentLerpTime += Time.deltaTime;
        if(currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }

        float movement = currentLerpTime / lerpTime;
        sack.transform.position = Vector3.Lerp(startPos,endPos,movement);
		
	}
}
