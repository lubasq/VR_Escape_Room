using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

    public GameObject loadingScreen;


    public void LoadingScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("EscapeRoom");
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
