using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using UnityEditor;


public class GameCursor : MonoBehaviour {
    [SerializeField] private Camera viewCamera;
    [SerializeField] private GameObject gameCursorPrefab;
    [SerializeField] private GameObject teleportPrefab;
    [SerializeField] private Transform Player;
    [SerializeField] private float RayLenght = 2f;

    private GameObject cursorInstance;
    private GameObject teleportInstance;

    void Start () {
        cursorInstance = Instantiate(gameCursorPrefab);
        teleportInstance = Instantiate(teleportPrefab);
        cursorInstance.SetActive(true);
        teleportInstance.SetActive(false);
    }
	
	void Update () {
        UpdateCursor();
        CheckInput();
    }

    private void UpdateCursor()
    {
        Ray ray = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {   if (hit.collider.tag == "Ground" && Physics.Raycast(ray, out hit, RayLenght))
            {
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
            cursorInstance.transform.position = ray.origin + ray.direction.normalized;
            cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -ray.direction);
        }
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        if (teleportInstance.activeInHierarchy)
        {
            Vector3 markerPosition = teleportInstance.transform.position;
            Player.position = new Vector3(markerPosition.x, Player.position.y, markerPosition.z);
        }
    }
}