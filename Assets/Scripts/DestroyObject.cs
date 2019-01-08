using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// @author Adrian Madoń 

public class DestroyObject : MonoBehaviour {


    void Start()
    {
        Destroy(transform.parent.gameObject);
    }
}
