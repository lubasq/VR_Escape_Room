using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour {

    public GameObject loadingScreen;


    public void LoadingScene()
    {
        loadingScreen.SetActive(true);
    }
}
