using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDeactivater : MonoBehaviour
{

    public List<GameObject> leversList;


    void Start()
    {
    }

    void Update()
    {
        if (AllLeversCorrect() ) {
            foreach(var lever in leversList)
            {
                lever.tag = "Untagged";
            }
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