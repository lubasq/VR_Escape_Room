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
    public GameObject zalogowany_;
    public GameObject niezalogowany_;
    string conn;

    // Use this for initialization
    void Start()
    {
#if UNITY_EDITOR
        conn = "URI=file:" + Application.dataPath + "/StreamingAssets/" + "Database.db";
#endif

#if UNITY_ANDROID
        string filepath = Application.persistentDataPath + "/" + "Database.db";
        if (!File.Exists(filepath))
        {
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + "Database.db");
            while (!loadDB.isDone) { }
            File.WriteAllBytes(filepath, loadDB.bytes);
        }
        conn = "URI=file:" + filepath;
#endif
    }

    // Update is called once per frame
    void Update()
    {        
    }


    public void TaskOnClick()
    {
        LoginIn();
    }
        
    public void LoginIn()
    {
        
        Debug.Log("Persistent" + Application.persistentDataPath);
        Debug.Log("dataPath" + Application.dataPath);

        List<User> uzytkownik = new List<User>();

        test.text = conn;

        //IDbConnection dbconn;
        SqliteConnection dbconn =  new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database. TU SIE COS SYPIE I DALEJ NIE IDZIE
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM Users WHERE login = '" + login.text + "' AND password = '" + password.text + "';";
        Debug.Log(sqlQuery);
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
           niezalogowanykomunikat.text = "Niezalogowano ;p";
        }


        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}