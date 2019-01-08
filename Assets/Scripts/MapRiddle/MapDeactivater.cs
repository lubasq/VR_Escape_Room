using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public class MapDeactivater : MonoBehaviour {

    [SerializeField] private GameObject map;

    public GameObject pinPinned;

    void Start () {
		
	}
	
	void Update () {
		if(pinPinned.activeSelf)
        {
            map.tag = "Untagged";
        }
	}
}
