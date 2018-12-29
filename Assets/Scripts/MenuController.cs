using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public bool pause = false;

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
        GameVariables.keyCount = 0;
        GameVariables.buttonPressed = false;
        GameVariables.gotPin = false;
    }

    public void GamePause()
    {
        pause = !pause;
        if (pause == true)
        {
            Time.timeScale = 0;
        }
        else if (pause == false)
        {
            Time.timeScale = 1;
        }        
    }
}
