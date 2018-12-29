using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorForMap : MonoBehaviour {

   // private HitReceiver hitScript;
    private Animator anim;

    // Use this for initialization
    void Start () {
        //hitScript = GetComponent<HitReceiver>();
        anim = GetComponent<Animator>();
        //hitScript.enabled = false;
        anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameVariables.gotPin == true) {
            anim.enabled = true;
           // hitScript.enabled = true;
        }
	}
}
