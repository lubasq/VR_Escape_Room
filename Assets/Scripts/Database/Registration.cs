using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using System.Data;

public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_InputField login;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_InputField email;
    [SerializeField] private TMP_Text registrationAlert;
    private string error = "";
    

    public void RegisterPlayer()
    {
        global::Database register = new global::Database();
        if (ValidateData(login.text, password.text, email.text) && !PlayerExist(login.text))
        {
            if (register.DBInsert("Users", new string[] { "login", "password", "email", "user_status" }, new string[] { login.text, password.text, email.text, "1" }))
            {
                registrationAlert.text = "Account created succesfully. \n You can now log in and play!";
            }
            else
            {
                registrationAlert.text = "Ooops, something wrong! \n Please check your data and try again.";
            }
            register.DBClose();
            register = null;
        }
        else
        {
            if (error.Length > 0)
            {
                registrationAlert.text = error;
            }
            else
            {
                registrationAlert.text = "User with this login already exist.";
            }
        }

    }

    private bool ValidateData(string login, string password, string email)
    {
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

        string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";
        var emailRegex = new Regex(emailPattern);
        if (!emailRegex.IsMatch(email))
        {
            Debug.Log(email);
            error += "\nEmail incorrect.";        
        }

        //show info about incorrect data
        if (error.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool PlayerExist(string login)
    {
        bool statement = false;
        global::Database DB = new global::Database();
        IDataReader reader = DB.DBSelect("Users", new string[] { "login" }, new string[] { "login" }, new string[] { login }, new string[] { }, "");

        //check if any player with this login exist
        while (reader.Read())
        {
            statement = true;            
        }
        //close connection 
        DB.DBClose();
        DB = null;
        return statement;
    }
}
