using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using TMPro;

public class Registration : MonoBehaviour
{
    public TMP_InputField login;
    public TMP_InputField password;
    public TMP_InputField email;
    public GameObject registered;
    public GameObject notRegistered;
    public TMP_Text notRegisteredAlert;
    public TMP_Text RegisteredAlert;

    private void Start()
    {

    }

    
    public void RegisterPlayer()
    {
        //rejestrowanie użytkownika
        global::Database register = new global::Database();

        if( register.DBInsert("Users", new string[] { "login", "password", "email" }, new string[] { login.text, password.text, email.text }) )
        {
            //Zarejestrowano pomyślnie
            registered.SetActive(true);
            notRegistered.SetActive(false);
            RegisteredAlert.text = "Account created succesfully. \n You can now log in and play!";
        }
        else
        {
            //Błąd podczas rejestracji
            notRegisteredAlert.text = "Ooops, something wrong! \n Please check your data and try again.";
        }

        //Zamknij połączenie z bazą danych, zniszcz obiekt 
        register.DBClose();
        register = null;

    }
}
