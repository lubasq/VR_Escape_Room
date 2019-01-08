using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeversCorrectness : MonoBehaviour {

    private WeightSystemController[] removeScript;
    private Animation anim;

	void Start () {
        removeScript = GetComponentsInChildren<WeightSystemController>();
        anim = GetComponent<Animation>();
        anim.wrapMode = WrapMode.ClampForever;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(GameVariables.sacksInRow) {
             foreach(WeightSystemController remover in removeScript) {
                Destroy(remover);
            }
            anim.Play();
        }

	}
}
