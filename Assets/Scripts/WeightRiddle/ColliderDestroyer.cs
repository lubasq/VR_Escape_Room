using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDestroyer : MonoBehaviour {

    private BoxCollider coll;

	void Start () {
        coll = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameVariables.leversMoving) {
            coll.enabled = false;
        }
        else
            coll.enabled = true;
	}
}
