using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AdminController : MonoBehaviour {

    [SerializeField] private TMP_InputField search;

    public void BanPlayer()
    {
        //user_status = 0
    }

    public void DeletePlayer()
    {
        //user_status = -1
    }

    public void UnbanPlayer()
    {
        //user_status = 1
    }

    public void SearchPlayer()
    {
        //search.text  -  searched var
        Debug.Log("You are looking for player " + search.text);
    }
}
