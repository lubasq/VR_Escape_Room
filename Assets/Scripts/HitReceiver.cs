using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReceiver : MonoBehaviour {

    private Animator anim;
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnRayHit()
    {
        if (Input.GetButtonDown("Fire1") && !anim.GetBool("isOpen")) {
            anim.SetBool("isOpen", true);
        }
        else if (Input.GetButtonDown("Fire1") && anim.GetBool("isOpen")) {
            anim.SetBool("isOpen", false);
        }
    }
}
