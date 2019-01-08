using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public class BookcaseMover : MonoBehaviour {

    private Animation anim;

    void Start () {
        anim = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameVariables.buttonPressed) {
            anim.Play();
            GameVariables.buttonPressed = false;
        }
    }
}
