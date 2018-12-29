using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorForPin : MonoBehaviour
{

    void OnDestroy()
    {
            GameVariables.gotPin = true;
    }
    }