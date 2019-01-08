using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public class LeversCorrectness : MonoBehaviour {

    private WeightRiddleController[] removeScript;
    private Animation anim;

	void Start () {
        removeScript = GetComponentsInChildren<WeightRiddleController>();
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.ClampForever;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(GameVariables.sacksInRow) {
             foreach(WeightRiddleController remover in removeScript) {
                Destroy(remover);
            }
            anim.Play();
        }

	}
}
