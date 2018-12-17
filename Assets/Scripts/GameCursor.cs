using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using UnityEditor;


public class GameCursor : MonoBehaviour
{
    public Camera viewCamera;
    [SerializeField] private GameObject gameCursorPrefab;
    [SerializeField] private GameObject teleportPrefab;
    [SerializeField] private GameObject handPrefab;
    [SerializeField] private Transform Player;
    [SerializeField] private float RayLenght = 2f;

    private GameObject cursorInstance;
    private GameObject teleportInstance;
    private GameObject handInstance;

    // Use this for initialization
    void Start()
    {
        cursorInstance = Instantiate(gameCursorPrefab);
        teleportInstance = Instantiate(teleportPrefab);
        handInstance = Instantiate(handPrefab);
        cursorInstance.SetActive(true);
        teleportInstance.SetActive(false);
        handInstance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursor();
        CheckInput();

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
            if (hit.collider.tag == "Ground" && Physics.Raycast(ray, out hit, RayLenght))
            {
                // If the ray hits something, set the position to the hit point and rotate based on the normal vector of the hit
                teleportInstance.SetActive(true);
                cursorInstance.SetActive(false);
                teleportInstance.transform.position = hit.point;
                teleportInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            else
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

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider != null && Physics.Raycast(ray, out hit, RayLenght - 0,5) && hit.collider.tag == "Activable")
            {
                handInstance.SetActive(true);
                cursorInstance.SetActive(false);
                var hitReceiver = hit.collider.gameObject.GetComponent<HitReceiver>();               
                handInstance.transform.position = cursorInstance.transform.position;
                handInstance.transform.rotation = cursorInstance.transform.rotation;
                float y = handInstance.transform.eulerAngles.y;
                float z = handInstance.transform.eulerAngles.z;
                handInstance.transform.Translate(Vector3.back * 0.05f);
                handInstance.transform.rotation = Quaternion.Euler(-45f, y, z);               
                if (hitReceiver != null)
                {
                    hitReceiver.OnRayHit();
                }
            }
            else
            {
                handInstance.SetActive(false);
            }
        }
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // If it's not a double click, it's a single click.
            // If anything has subscribed to OnClick call it.
            Teleport();
        }
    }

    public void Teleport()
    {
        if (teleportInstance.activeInHierarchy)
        {
            Vector3 markerPosition = teleportInstance.transform.position;
            Player.position = new Vector3(markerPosition.x, Player.position.y, markerPosition.z);
        }
    }

}