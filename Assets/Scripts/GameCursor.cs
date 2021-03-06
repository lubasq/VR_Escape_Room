﻿using System.Collections;
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
    [SerializeField] private GameObject coloredHandPrefab;
    [SerializeField] private Transform Player;
    [SerializeField] private float RayLenght = 3f;
    [SerializeField] private GameObject pauseObject;
    [SerializeField] private GameObject endGameObject;
    [SerializeField] private AudioSource stepSound;

    private GameObject cursorInstance;
    private GameObject teleportInstance;
    private GameObject handInstance;
    private GameObject coloredHandInstance;
    private bool pause = false;
    public MenuController pauseScript;
    private static float a = -1.2f;
    private static float b = 1.5f;
    private static float c = 5.0f;
    Vector3 endPos = new Vector3(a, b, c);
    private bool dbSaverStatus;

    void Start()
    {
        dbSaverStatus = false;
        Time.timeScale = 1;
        cursorInstance = Instantiate(gameCursorPrefab);
        teleportInstance = Instantiate(teleportPrefab);
        handInstance = Instantiate(handPrefab);
        coloredHandInstance = Instantiate(coloredHandPrefab);
        cursorInstance.SetActive(true);
        teleportInstance.SetActive(false);
        handInstance.SetActive(false);
        coloredHandInstance.SetActive(false);
        pauseObject.SetActive(false);
        stepSound = GetComponent<AudioSource>();
    }

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
        if (pause == false)
        {
            if (Physics.Raycast(ray, out hit, RayLenght))
            {
                if (Physics.Raycast(ray, out hit, RayLenght) && gameObject.tag == "InputField")
                {
                    cursorInstance.transform.position = hit.point;
                    cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                }
            }

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
                if (Physics.Raycast(ray, out hit, RayLenght - 0, 5) && hit.collider.tag == "Activable")
                {
                    handInstance.SetActive(true);
                    cursorInstance.SetActive(false);
                    handInstance.transform.position = cursorInstance.transform.position;
                    handInstance.transform.rotation = cursorInstance.transform.rotation;
                    float y = handInstance.transform.eulerAngles.y;
                    float z = handInstance.transform.eulerAngles.z;
                    handInstance.transform.Translate(Vector3.back * 0.05f);
                    handInstance.transform.rotation = Quaternion.Euler(-50f, y, z);
                    var hitReceiver = hit.collider.gameObject.GetComponent<HitReceiver>();
                    if (hitReceiver != null)
                    {
                        hitReceiver.OnRayHit();
                    }
                }
                else
                {
                    handInstance.SetActive(false);
                }
                if (hit.collider != null && Physics.Raycast(ray, out hit, RayLenght - 0, 5) && hit.collider.tag == "Collectable")
                {

                    handInstance.SetActive(false);
                    cursorInstance.SetActive(false);
                    coloredHandInstance.SetActive(true);
                    coloredHandInstance.transform.position = cursorInstance.transform.position;
                    coloredHandInstance.transform.rotation = cursorInstance.transform.rotation;
                    float y = coloredHandInstance.transform.eulerAngles.y;
                    float z = coloredHandInstance.transform.eulerAngles.z;
                    coloredHandInstance.transform.rotation = Quaternion.Euler(-45f, y, z);
                    var hitReceiver = hit.collider.gameObject.GetComponent<HitReceiver>();
                    if (hitReceiver != null)
                    {
                        hitReceiver.CollectItem();
                    }
                }
                else
                {
                    coloredHandInstance.SetActive(false);
                }
            }
        }
        if (pause == true && Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.tag == "Canvas")
            {
                cursorInstance.SetActive(true);
                teleportInstance.SetActive(false);
                cursorInstance.transform.position = hit.point;
                cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                float y = cursorInstance.transform.eulerAngles.y;
                float z = cursorInstance.transform.eulerAngles.z;
                cursorInstance.transform.rotation = Quaternion.Euler(180f, y, z);
            }
            else if (hit.collider.tag == "EndCanvas")
            {
                cursorInstance.SetActive(true);
                teleportInstance.SetActive(false);
                cursorInstance.transform.position = hit.point;
                cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                float y = cursorInstance.transform.eulerAngles.y;
                float z = cursorInstance.transform.eulerAngles.z;
                cursorInstance.transform.rotation = Quaternion.Euler(0f, y, z);
            }
        }
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {            
            Teleport();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            pauseScript.GamePause();
            PauseCanvas();      
        }
        if (Input.GetButtonDown("Fire1") && viewCamera.transform.position.z > 2.5)
        {
            Ending();
        }
    }

    public void Teleport()
    {
        if (teleportInstance.activeInHierarchy)
        {
            stepSound.Play();
            Vector3 markerPosition = teleportInstance.transform.position;
            Player.position = new Vector3(markerPosition.x, Player.position.y, markerPosition.z);
        }
    }

    public void PauseCanvas()
    {
        pause = !pause;
        if (pause == false)
        {
            pauseObject.SetActive(false);
        } else if (pause == true)
        {
            pauseObject.SetActive(true);
            PauseCamera();
        }
    }

    public void PauseCamera()
    {
        float _x = -1.5f;
        float _y = 1.5f;
        float _z = 0f;
        Player.position = new Vector3(_x,_y,_z);
        Vector3 xD = new Vector3(0, 0, 0);
        viewCamera.transform.rotation = Quaternion.FromToRotation(Vector3.up, xD);
    }

    public void Ending()
    {
        if (!dbSaverStatus)
        {
            Time.timeScale = 0;
            Timer var = new Timer();
            var.SaveScoreToDB();
            endGameObject.SetActive(true);
            pause = true;
            Player.position = endPos;
            dbSaverStatus = !dbSaverStatus;
        }
    }
}