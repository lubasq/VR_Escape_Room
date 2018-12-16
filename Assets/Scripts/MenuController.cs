using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public void Exit()
    {
        Application.Quit();
    }

    public void GameSceneLoader()
    {
        SceneManager.LoadScene("TestRoom");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
