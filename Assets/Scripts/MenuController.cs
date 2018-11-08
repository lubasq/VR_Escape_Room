using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void Exit()
    {
        Application.Quit();
    }

    public void GameScene()
    {
        //SceneManager.LoadScene("TestRoom", LoadSceneMode.Additive);
        //SceneManager.LoadScene("TestRoom"); <- najpierw to spróbować@
    }

    public void MenuScene()
    {
        //SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        //SceneManager.LoadScene("MainMenu"); <- najpierw to spróbować@
    }
}
