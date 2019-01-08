using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public class LeverDeactivater : MonoBehaviour
{

    public List<GameObject> leversList;

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