﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReceiver : MonoBehaviour
{
    public bool locked;
    private Animator anim;
    public GameObject key;
    public int keyVariable;
    public int keyWorth;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnRayHit()
    {
        if (Input.GetButtonDown("Fire1") && !anim.GetBool("isOpen") && locked && GameVariables.keyCount == keyVariable) {
            anim.SetBool("isOpen", true);
        }
        else if (Input.GetButtonDown("Fire1") && anim.GetBool("isOpen") && locked && GameVariables.keyCount == keyVariable) {
            anim.SetBool("isOpen", false);
        }
        else if (Input.GetButtonDown("Fire1") && !anim.GetBool("isOpen") && !locked) {
            anim.SetBool("isOpen", true);
        }
        else if (Input.GetButtonDown("Fire1") && anim.GetBool("isOpen") && !locked) {
            anim.SetBool("isOpen", false);
        }
    }

    public void AddKey()
    {
        GameVariables.keyCount += keyWorth;
        Destroy(key);
        Debug.Log(GameVariables.keyCount);
    }

}


