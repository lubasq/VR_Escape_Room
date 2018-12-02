using UnityEngine;
using System.Collections;
using System;

public class SurfaceCursor : MonoBehaviour {
    public Camera viewCamera;
    public GameObject cursorPrefab;
    public GameObject teleportPrefab;

    private GameObject cursorInstance;
    private GameObject teleportInstance;

	// Use this for initialization
	void Start () {
        cursorInstance = Instantiate(cursorPrefab);
        teleportInstance = Instantiate(teleportPrefab);
        cursorInstance.SetActive(true);
        teleportInstance.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
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
        {   if (hit.collider.tag == "Ground")
            {
                // If the ray hits something, set the position to the hit point and rotate based on the normal vector of the hit
                teleportInstance.SetActive(true);
                cursorInstance.SetActive(false);
                teleportInstance.transform.position = hit.point;
                teleportInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            } else
            {
                teleportInstance.SetActive(false);
                cursorInstance.SetActive(true);
            }
            
        
        }
        else
        {
            // If the ray doesn't hit anything, set the position to the maxCursorDistance and rotate to point away from the camera
            cursorInstance.transform.position = ray.origin + ray.direction.normalized;
            cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
        }
    }
}
