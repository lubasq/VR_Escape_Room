using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public class OpenSesame : MonoBehaviour
{

    private Animation anim;
    private bool animBlocker = true;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if (AllLeversCorrect() && animBlocker) {
            anim.Play();
            animBlocker = false;
        }

    }

    private bool AllLeversCorrect()
    {
        for (int i = 0; i < GameVariables.correctLeverState.Length; ++i)
        {
            if (GameVariables.correctLeverState[i] == false)
                return false;
        }
        return true;
    }
}