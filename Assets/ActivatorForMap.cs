using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorForMap : MonoBehaviour {

    private HitReceiver hitScript;

    // Use this for initialization
    void Start () {
        hitScript = GetComponent<HitReceiver>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameVariables.gotPin == true) {
            hitScript.enabled = true;
        }
	}
}
