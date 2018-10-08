using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using TMPro;

public class Register : MonoBehaviour {
    public TMP_InputField login;
    public TMP_InputField password;
    public TMP_InputField email;


    private void Start()
    {
        
    }
    // Use this for initialization
    public void  RegisterPlayer() {       
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        Debug.Log(email.text);
        string sqlQuery = "INSERT INTO Users (login, password, email) VALUES ("+ login.text + ", " + password.text + " ," + email.text +");";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
