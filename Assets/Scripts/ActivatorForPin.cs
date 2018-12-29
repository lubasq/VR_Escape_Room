using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorForPin : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            GameVariables.gotPin = true;
        }

    }
}