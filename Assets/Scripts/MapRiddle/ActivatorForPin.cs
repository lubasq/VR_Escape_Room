using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public class ActivatorForPin : MonoBehaviour
{

    void OnDestroy()
    {
            GameVariables.gotPin = true;
    }
    }