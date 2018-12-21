using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using TMPro;

public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private GameObject registered;
    [SerializeField] private GameObject notRegistered;
    [SerializeField] private TMP_Text notRegisteredAlert;
    [SerializeField] private TMP_Text RegisteredAlert;
//removed start    
    public void RegisterPlayer()
    {
        global::Database register = new global::Database();

        if( register.DBInsert("Users", new string[] { "login", "password", "email" }, new string[] { login.text, password.text, email.text }) )
        {
            registered.SetActive(true);
            notRegistered.SetActive(false);
            RegisteredAlert.text = "Account created succesfully. \n You can now log in and play!";
        }
        else
        {
            notRegisteredAlert.text = "Ooops, something wrong! \n Please check your data and try again.";
        }
        register.DBClose();
        register = null;

    }
}
