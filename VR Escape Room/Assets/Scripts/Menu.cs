﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void Wyjscie()
    {
        Application.Quit();
    }

    public void Scene()
    {
        //SceneManager.LoadScene("TestRoom", LoadSceneMode.Additive);
    }

}
