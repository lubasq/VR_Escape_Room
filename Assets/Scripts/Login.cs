using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using UnityEditor;




public class UserData : IEquatable<UserData>
{
    public int _id { get; set; }

    public string login { get; set; }

    public string password { get; set; }

    public string email { get; set; }

    public bool Equals(UserData other)
    {
        if (other == null) return false;
        return (this._id.Equals(other._id));
    }
}

public class Login : MonoBehaviour
{
    public TMP_InputField login;
    public TMP_InputField password;
    public TMP_Text loggedIn;
    public TMP_Text notLoggedIn;
    public TMP_Text test;
    public GameObject loggedScene;
    public GameObject notLoggedScene;
    
    void Start()
    {
    }
    
    void Update()
    {        
    }

    public void TaskOnClick()
    {
        LoginIn();
    }
        
    private void LoginIn()
    {
        //sprawdzenie sciezek
        Debug.Log("Persistent path: " + Application.persistentDataPath);
        Debug.Log("dataPath path: " + Application.dataPath);
        //pobierz dane
        List<UserData> uzytkownik = new List<UserData>();
        global::Database user = new global::Database();
        IDataReader reader = user.DBSelect("Users", new string[] {}, new string[] { "login", "password" }, new string[] { login.text, password.text }, new string[] {}, "");

        //odczytaj dane i zamień w liste
        while (reader.Read())
        {
            uzytkownik.Add(new UserData() { _id = reader.GetInt32(0), login = reader.GetString(1), password = reader.GetString(2), email = reader.GetString(3) });
        }
        //Zamknij połączenie z bazą danych, zniszcz obiekt 
        user.DBClose();
        user = null;
        //Sprawdź czy istnieją jakiekolwiek rekordy - jeżeli tak, to znaczy
        //że jesteś zalogowany.
        if (uzytkownik.Count > 0)
        {           
            loggedIn.text = login.text;
            loggedScene.SetActive(true);
            notLoggedScene.SetActive(false);
        }
        else
        {
           notLoggedIn.text = "Oops, something went wrong!\n Please check your login or password and try again!";
        }
    }
}