using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;
using UnityEditor;
using System.Text.RegularExpressions;

public class UserData : IEquatable<UserData>
{
    public int _id { get; set; }

    public string login { get; set; }

    public string password { get; set; }

    public string email { get; set; }

    public int status { get; set; }

    public bool Equals(UserData other)
    {
        if (other == null) return false;
        return (this._id.Equals(other._id));
    }
}

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_Text loggedIn;
    [SerializeField] private TMP_Text notLoggedIn;
    [SerializeField] private GameObject loggedScene;
    [SerializeField] private GameObject notLoggedScene;
    [SerializeField] private GameObject adminPanel;

    public static string loginText;
    private int userStatus;

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
        //check path of database
        //Debug.Log("Persistent path: " + Application.persistentDataPath);
        //Debug.Log("dataPath path: " + Application.dataPath);
        if( ValidateData(login.text, password.text) )
        {
            //get data
            List<UserData> currentUser = new List<UserData>();
            global::Database user = new global::Database();
            IDataReader reader = user.DBSelect("Users", new string[] { }, new string[] { "login", "password" }, new string[] { login.text, password.text }, new string[] { }, "");
            
            //chage it to list, interface have no possibility to check if any rows exist.
            while (reader.Read())
            {
                currentUser.Add(new UserData() { _id = reader.GetInt32(0), login = reader.GetString(1), password = reader.GetString(2), email = reader.GetString(3), status= reader.GetInt32(4) });
               
            }
            //close connection 
            user.DBClose();
            user = null;
            //Sprawdź czy istnieją jakiekolwiek rekordy - jeżeli tak, to znaczy
            //że jesteś zalogowany.
            if (currentUser.Count > 0)
            {
                switch (currentUser[0].status)
                {
                    case -1:
                        notLoggedIn.text = "Your account has been deleted.";
                        break;
                    case 0:
                        notLoggedIn.text = "Your account has been banned.";
                        break;
                    case 1:
                        PlayerPrefs.SetInt("id", currentUser[0]._id);
                        loggedIn.text = login.text;
                        loggedScene.SetActive(true);
                        notLoggedScene.SetActive(false);
                        adminPanel.SetActive(false);
                        loginText = login.text;
                        break;
                    case 2:
                        PlayerPrefs.SetInt("id", currentUser[0]._id);
                        loggedIn.text = login.text;
                        loggedScene.SetActive(true);
                        notLoggedScene.SetActive(false);
                        adminPanel.SetActive(true);
                        loginText = login.text;
                        break;
                    default:
                        notLoggedIn.text = "Something went wrong.";
                        Debug.Log("Current user status: " + currentUser[0].status);
                        break;
                }
            }
            else
            {
                notLoggedIn.text = "Oops, something went wrong!\n Please check your login or password and try again!";
            }
        }
        
    }

    private bool ValidateData(string login, string password)
    {
        string error = "";
        var regex = new Regex("^[a-zA-Z0-9]{4,15}$");
        
        //if login is too short or contain illegal characters
        if (!regex.IsMatch(login))
        {
            error = "Login is too short, or contains illegal characters.";
        }

        if(!regex.IsMatch(password))
        {
            error += "\nPassword incorrect.";
        }

        //show info about incorrect data
        notLoggedIn.text = error;
        if (error.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}