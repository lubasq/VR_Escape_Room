using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using TMPro;
using System.Text.RegularExpressions;
using System.Net.Mail;

public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private GameObject registered;
    [SerializeField] private GameObject notRegistered;
    [SerializeField] private TMP_Text notRegisteredAlert;
    [SerializeField] private TMP_Text RegisteredAlert;
    

    public void RegisterPlayer()
    {
        global::Database register = new global::Database();
        if (ValidateData(login.text, password.text, email.text))
        {
            if (register.DBInsert("Users", new string[] { "login", "password", "email" }, new string[] { login.text, password.text, email.text }))
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

    private bool ValidateData(string login, string password, string email)
    {
        string error = "";
        var regex = new Regex("^[a-zA-Z0-9]{4,15}$");

        //if login is too short or contain illegal characters
        if (!regex.IsMatch(login))
        {
            error = "Login is too short, or contains illegal characters.";
        }

        if (!regex.IsMatch(password))
        {
            error += "\nPassword incorrect.";
        }

        try
        {
            MailAddress m = new MailAddress(email);

            //if(!m.Address == email)
            {
                error += "\nEmail incorrect.";
            }
        }
        catch(Exception ex)
        {
            error += "\nSomething went wrong with email validation.";
            Debug.Log("EMAIL: " + ex.Message);
        }

        //show info about incorrect data
        notRegisteredAlert.text = error;
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
