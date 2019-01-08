using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public class LidOpener : MonoBehaviour {

    [SerializeField] private Animator anim;
    public GameObject[] coins = new GameObject[3];
    private bool allInserted = true;


    void Start () {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        allInserted = true;

        for (int i=0; i<coins.Length;++i) {
            if(!coins[i].activeInHierarchy) {
                allInserted = false;
                break;
            }
        }
        if(allInserted) {
            anim.enabled = true;
        }


    }
	}
