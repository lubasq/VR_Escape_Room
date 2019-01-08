using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;

public class AdminController : MonoBehaviour
{
    [SerializeField] private TMP_InputField search;
    [SerializeField] private TMP_Text alert;
    [SerializeField] private TMP_Text playerData;
    private int[] user = new int[] { 99, 99 };         //[0] - ID, [1] - status
    private global::Database DB;

    public void BanPlayer()
    {
        //user_status = 0
        SearchPlayer();
        switch (user[1])
        {
            case -1:
                //Debug.Log("Player already deleted.");
                alert.text = "Player already deleted.";
                break;
            case 0:
                //Debug.Log("Player already banned");
                alert.text = "Player already banned.";
                break;
            case 1:
                DB = new global::Database();

                if (DB.DBUpdate("Users", new string[] { "user_status" }, new string[] { "0" }, new string[] { "id_user" }, new string[] { user[0].ToString() }))
                {
                    //Debug.Log("Banned succesfully.");
                    alert.text = "Banned succesfully.";
                }
                else
                {
                    //Debug.Log("Problems with banning.");
                    alert.text = "Failed.";
                }
                DB.DBClose();
                DB = null;
                break;
            case 2:
                //Debug.Log("Are u crazy? Don't try to change admin status!");
                alert.text = "You can't change status of admin.";
                break;
            default:
                //Debug.Log("There is no info about player?");
                alert.text = "Player doesn't exist.";
                break;
        }
    user[0] = 99;
    }

    public void DeletePlayer()
    {
        //user_status = -1
        SearchPlayer();
        switch (user[1])
        {
            case -1:
                //Debug.Log("Player already banned.");
                alert.text = "Player already deleted, can't be banned.";
                break;
            case 0:
                //Debug.Log("Player already banned");
                alert.text = "Player already banned.";
                break;
            case 1:
                DB = new global::Database();

                if (DB.DBUpdate("Users", new string[] { "user_status" }, new string[] { "-1" }, new string[] { "id_user" }, new string[] { user[0].ToString() }))
                {
                    //Debug.Log("Succesfully deleted");
                    alert.text = "Succesfully deleted";
                }
                else
                {
                    //Debug.Log("Problems with removing.");
                    alert.text = "Problems with removing.";
                }
                DB.DBClose();
                DB = null;
                break;
            case 2:
                //Debug.Log("Are u mad? Don't try to change admin status!");
                alert.text = "You can't change status of admin.";
                break;
            default:
                //Debug.Log("There is no info about player?");
                alert.text = "Player doesn't exist.";
                break;
        }
    user[0] = 99;
    }

    public void UnbanPlayer()
    {
        //user_status = 1
        SearchPlayer();
        switch (user[1])
        {
            case -1:
                //Debug.Log("Player already deleted, you couldn't unban him.");
                alert.text = "You can't unban deleted player";
                break;
            case 0:
                DB = new global::Database();

                if (DB.DBUpdate("Users", new string[] { "user_status" }, new string[] { "1" }, new string[] { "id_user" }, new string[] { user[0].ToString() }))
                {
                    //Debug.Log("Unbanned succesfully");
                    alert.text = "Unbanned succesfully";
                }
                else
                {
                   //Debug.Log("Problems with unbanning.");
                    alert.text = "Problems with unbanning.";
                }
                DB.DBClose();
                DB = null;
                break;
            case 1:
                //Debug.Log("Player isn't banned.");
                alert.text = "Player isn't banned.";
                break;
            case 2:
                //Debug.Log("Are u mad? Don't try to change admin status!");
                alert.text = "You can't change status of admin.";
                break;
            default:
               //Debug.Log("There is no info about player?");
                alert.text = "Player doesn't exist.";
                break;
        }
    user[0] = 99;
    }

    public void SearchPlayer()
    {
        //search.text  -  searched var
        //Debug.Log("You are looking for player " + search.text);
        bool userExist = false;
        DB = new global::Database();
        IDataReader reader = DB.DBSelect("Users", new string[] { }, new string[] { "login", }, new string[] { search.text }, new string[] { }, "");

        //chage it to array of 2 elements, status and ID, interface have no possibility to check if any rows exist.
        while (reader.Read())
        {
            user = new int[2] { reader.GetInt32(0), reader.GetInt32(4) };
            userExist = true;
        }
        //close connection 
        DB.DBClose();
        DB = null;
        Debug.Log(user[0]);
        if (!userExist)
        {
            user[0] = 99;
        }

        if (user[0] != 99)
        {
            //Debug.Log("Info about player confirmed");
            playerData.text = "You are changing " + search.text + "'s status.";
        }
        else
        {
            //Debug.Log("Wrong login. Check it and try again.");
            playerData.text = "Wrong login. Check it and try again.";
        }

        
    }
}
