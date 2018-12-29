using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorForMap : MonoBehaviour {

    private Animator anim;

    void Start () {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        anim.SetBool("isOpen", false);
    }
	
	void Update () {
            if (GameVariables.gotPin == true) {
            anim.enabled = true;
         }
          else {
            anim.SetBool("isOpen", false);
         }
    }
}
