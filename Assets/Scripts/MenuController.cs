using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void Exit()
    {
        Application.Quit();
    }

    public void GameSceneLoader()
    {
        SceneManager.LoadScene("TestRoom");
    }
}
