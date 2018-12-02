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
    public GameObject menuCursorPrefab;

    private GameObject cursorInstance;
 
    // Use this for initialization
    void Start()
    {
        cursorInstance = Instantiate(menuCursorPrefab);
        cursorInstance.SetActive(true);
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
            menuCursorPrefab.transform.position = hit.point;
            menuCursorPrefab.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        
    }
}
