using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

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
        GameVariables.keyCount = 0;
        GameVariables.buttonPressed = false;
        GameVariables.gotPin = false;
        for (int i = 0; i < GameVariables.correctLeverState.Length; ++i)
        {
            GameVariables.correctLeverState[i] = false;
        }
        SceneManager.LoadScene("TestRoom");
    }

    public void MenuScene()
    {
        GameVariables.keyCount = 0;
        GameVariables.buttonPressed = false;
        GameVariables.gotPin = false;
        for (int i = 0; i < GameVariables.correctLeverState.Length; ++i)
        {
            GameVariables.correctLeverState[i] = false;
        }
        SceneManager.LoadScene("MainMenu");
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
