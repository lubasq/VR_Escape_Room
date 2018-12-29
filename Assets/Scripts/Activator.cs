using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    private Animator anim;
    private Collider objectCol;

    void Start () {
        anim = GetComponent<Animator>();
        objectCol = GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(anim.GetBool("isOpen"));
        if (anim.GetBool("isOpen")== true)   {
            GameVariables.buttonPressed = true;
            anim.SetBool("isOpen",false);
            objectCol.enabled = !objectCol.enabled;
        }

    }
}
