using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class AdminController : MonoBehaviour
{

    [SerializeField] private TMP_InputField search;
    private int[] user;         //[0] - ID, [1] - status
    private global::Database DB;

    public void BanPlayer()
    {
        //user_status = 0
        SearchPlayer();
        switch (user[1])
        {
            case -1:
                Debug.Log("Player already deleted, you couldn't ban him.");
                break;
            case 0:
                Debug.Log("Player already banned");
                break;
            case 1:
                DB = new global::Database();

                if (DB.DBUpdate("Users", new string[] { "status" }, new string[] { "0" }, new string[] { "id" }, new string[] { user[0].ToString() }))
                {
                    Debug.Log("Banned succesfully");
                }
                else
                {
                    Debug.Log("Problems with banning.");
                }
                DB.DBClose();
                DB = null;
                break;
            case 2:
                Debug.Log("Are u mad? Don't try to change admin status!");
                break;
            default:
                Debug.Log("There is no info about player?");
                break;
        }
    }

    public void DeletePlayer()
    {
        //user_status = -1
        SearchPlayer();
        switch (user[1])
        {
            case -1:
                Debug.Log("Player already deleted, you couldn't ban him.");
                break;
            case 0:
                Debug.Log("Player already banned");
                break;
            case 1:
                DB = new global::Database();

                if (DB.DBUpdate("Users", new string[] { "status" }, new string[] { "-1" }, new string[] { "id" }, new string[] { user[0].ToString() }))
                {
                    Debug.Log("Banned succesfully");
                }
                else
                {
                    Debug.Log("Problems with banning.");
                }
                DB.DBClose();
                DB = null;
                break;
            case 2:
                Debug.Log("Are u mad? Don't try to change admin status!");
                break;
            default:
                Debug.Log("There is no info about player?");
                break;
        }
    }

    public void UnbanPlayer()
    {
        //user_status = 1
        SearchPlayer();
        switch (user[1])
        {
            case -1:
                Debug.Log("Player already deleted, you couldn't unban him.");
                break;
            case 0:
                DB = new global::Database();

                if (DB.DBUpdate("Users", new string[] { "status" }, new string[] { "1" }, new string[] { "id" }, new string[] { user[0].ToString() }))
                {
                    Debug.Log("Unbanned succesfully");
                }
                else
                {
                    Debug.Log("Problems with unbanning.");
                }
                DB.DBClose();
                DB = null;
                break;
            case 1:
                Debug.Log("Player isn't banned now.");
                break;
            case 2:
                Debug.Log("Are u mad? Don't try to change admin status!");
                break;
            default:
                Debug.Log("There is no info about player?");
                break;
        }
    }

    public void SearchPlayer()
    {
        //search.text  -  searched var
        Debug.Log("You are looking for player " + search.text);

        DB = new global::Database();
        IDataReader reader = DB.DBSelect("Users", new string[] { }, new string[] { "login", }, new string[] { search.text }, new string[] { }, "");

        //chage it to array of 2 elements, status and ID, interface have no possibility to check if any rows exist.
        while (reader.Read())
        {
            user = new int[2] { reader.GetInt32(0), reader.GetInt32(4) };
        }
        //close connection 
        DB.DBClose();
        DB = null;

        if (user[0] != null)
        {
            Debug.Log("Info about player confirmed");
        }
        else
        {
            Debug.Log("Wrong login. Check it and try again.");
        }
    }
}
