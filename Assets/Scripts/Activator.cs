using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    private Animator anim;
    private Collider collider;

    void Start () {
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetBool("isOpen"))   {
            GameVariables.buttonPressed = true;
            anim.SetBool("isOpen",false);
            collider.enabled = !collider.enabled;
        }

    }
}
