using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorForCoin : MonoBehaviour {

    // Use this for initialization
    void OnDestroy()
    {
        GameVariables.gotCoin += 1;
    }
}