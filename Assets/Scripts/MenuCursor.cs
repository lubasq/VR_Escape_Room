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
    public Camera viewCamera;
    public GameObject menuCursor;
 
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursor();
    }

    /// <summary>
    /// Updates the cursor based on what the camera is pointed at.
    /// </summary>
    private void UpdateCursor()
    {
        // Create a gaze ray pointing forward from the camera
        Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            // If the ray hits something, set the position to the hit point and rotate based on the normal vector of the hit
            menuCursor.transform.position = hit.point;
            menuCursor.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        
    }
}
