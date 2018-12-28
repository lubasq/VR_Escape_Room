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
    [SerializeField] private GameObject coloredHandPrefab;
    [SerializeField] private Transform Player;
    [SerializeField] private float RayLenght = 3f;
    [SerializeField] private GameObject pauseObject;


    private GameObject cursorInstance;
    private GameObject teleportInstance;
    private GameObject handInstance;
    private GameObject coloredHandInstance;
    private bool pause = false;
    public MenuController pauseScript;
    Vector3 orginalPos;


    void Start()
    {
        cursorInstance = Instantiate(gameCursorPrefab);
        teleportInstance = Instantiate(teleportPrefab);
        handInstance = Instantiate(handPrefab);
        coloredHandInstance = Instantiate(coloredHandPrefab);
        cursorInstance.SetActive(true);
        teleportInstance.SetActive(false);
        handInstance.SetActive(false);
        coloredHandInstance.SetActive(false);
        //pauseCanvas.enabled = pause;
        pauseObject.SetActive(false);
        orginalPos = new Vector3(viewCamera.transform.position.x, viewCamera.transform.position.y, viewCamera.transform.position.z);
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
                    handInstance.transform.rotation = Quaternion.Euler(-45f, y, z);
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
                if (hit.collider != null && Physics.Raycast(ray, out hit, RayLenght - 0, 5) && hit.collider.tag == "Key")
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
                        hitReceiver.AddKey();
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
            if(hit.collider.tag == "Canvas")
            {
                cursorInstance.transform.position = hit.point;
                cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                float y = cursorInstance.transform.eulerAngles.y;
                float z = cursorInstance.transform.eulerAngles.z;
                cursorInstance.transform.rotation = Quaternion.Euler(180f, y, z);
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
    }

    public void Teleport()
    {
        if (teleportInstance.activeInHierarchy)
        {
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
        Player.position = orginalPos;
    }
}