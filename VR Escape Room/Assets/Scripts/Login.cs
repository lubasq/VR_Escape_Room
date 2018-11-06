using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using UnityEditor;




public class User : IEquatable<User>
{
    public int _id { get; set; }

    public string login { get; set; }

    public string password { get; set; }

    public string email { get; set; }

    public bool Equals(User other)
    {
        if (other == null) return false;
        return (this._id.Equals(other._id));
    }
}

public class Login : MonoBehaviour
{
    public TMP_InputField login;
    public TMP_InputField password;
    public TMP_Text zalogowany;
    public TMP_Text niezalogowanykomunikat;
    public TMP_Text test;
    public TMP_Text test2;
    public TMP_Text test3;
    public GameObject zalogowany_;
    public GameObject niezalogowany_;
    
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
        
    public void LoginIn()
    {
        //sprawdzenie sciezek
        Debug.Log("Persistent" + Application.persistentDataPath);
        Debug.Log("dataPath" + Application.dataPath);
        //pobierz dane
        List<User> uzytkownik = new List<User>();
        global::Database user = new global::Database();
        IDataReader reader = user.DBSelect("Users", new string[] { "login", "password" }, new string[] { login.text, password.text });
        //odczytaj dane i zamień w liste
        while (reader.Read())
        {
            uzytkownik.Add(new User() { _id = reader.GetInt32(0), login = reader.GetString(1), password = reader.GetString(2), email = reader.GetString(3) });
        }
        //Zamknij połączenie z bazą danych, zniszcz obiekt 
        user.DBClose();
        user = null;
        //Sprawdź czy istnieją jakiekolwiek rekordy - jeżeli tak, to znaczy
        //że jesteś zalogowany.
        if (uzytkownik.Count > 0)
        {           
            zalogowany.text = login.text;
            zalogowany_.SetActive(true);
            niezalogowany_.SetActive(false);
        }
        else
        {
           niezalogowanykomunikat.text = "Niezalogowano ;p";
        }
    }
}