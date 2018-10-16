using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;

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
    public GameObject zalogowany_;
    public GameObject niezalogowany_;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoginIn()
    {
        List<User> uzytkownik = new List<User>();
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM Users WHERE login = '" + login.text + "' AND password = '" + password.text + "';";
        Debug.Log(sqlQuery);
        Debug.Log("I WAS HERE Pog");
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            uzytkownik.Add(new User() { _id = reader.GetInt32(0), login = reader.GetString(1), password = reader.GetString(2), email = reader.GetString(3) });
        }
        //Debug.Log(uzytkownik.Count);
        if (uzytkownik.Count > 0)
        {
           /* foreach (User uzytkownika in uzytkownik)
            {
                Debug.Log("_id: " + uzytkownika._id);
            }*/
            zalogowany.text = login.text;
            zalogowany_.SetActive(true);
            niezalogowany_.SetActive(false);
            
        }
        else
        {
           niezalogowanykomunikat.text = "Niezalogowano :wykrzyknik:";
        }


        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}