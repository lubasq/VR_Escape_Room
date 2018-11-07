using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using TMPro;

public class Rejestracja : MonoBehaviour
{
    public TMP_InputField login;
    public TMP_InputField password;
    public TMP_InputField email;


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
        }
        else
        {
            //Błąd podczas rejestracji
        }

        //Zamknij połączenie z bazą danych, zniszcz obiekt 
        register.DBClose();
        register = null;

    }
}
