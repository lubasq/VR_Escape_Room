using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public GameObject Arrow;
    public float yAxis = 0.14f;

    void Update()
    {

        Arrow.transform.Translate(Vector3.up * yAxis);
    }
}