using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using UnityEditor;

public class MenuCursor : MonoBehaviour
{
    [SerializeField] private Camera viewCamera;
    [SerializeField] private GameObject menuCursor;
 
    void Start()
    {
    }

    void Update()
    {
        UpdateCursor();
    }

    private void UpdateCursor()
    {
        Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            menuCursor.transform.position = hit.point;
            menuCursor.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        
    }
}
