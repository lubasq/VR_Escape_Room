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
    }

    public void GamePause()
    {
        pause = !pause;
        if (pause == true)
        {
            Time.timeScale = 0;
            Debug.Log("Paused");
        }
        else if (pause == false)
        {
            Time.timeScale = 1;
            Debug.Log("Unpaused");
        }        
    }
}
