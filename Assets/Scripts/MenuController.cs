using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
   // public GameObject resetGlobalVariables;
    public bool pause = false;



    public void Exit()
    {
        Application.Quit();
    }

    public void GameSceneLoader()
    {
        SceneManager.LoadScene("EscapeRoom");
    }

    public void RestartScene()
    {
        GameVariables.resetVariables();
        SceneManager.LoadScene("EscapeRoom");
    }

    public void MenuScene()
    {
        //    GameVariables.gotKey = false;
        //    GameVariables.buttonPressed = false;
        //    GameVariables.gotPin = false;
        //    GameVariables.gotCoin = 0;
        //    for (int i = 0; i < GameVariables.correctLeverState.Length; ++i)
        //    {
        //        GameVariables.correctLeverState[i] = false;
        //   }
     //   resetGlobalVariables.GetComponent<GameVariables>().enabled = true;
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
