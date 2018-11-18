using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class Rank : MonoBehaviour {
    public TMP_Text playersLogin;
    public TMP_Text playersTime;
    // Use this for initialization
    void Start () {
        RankOfBestPlayers();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void RankOfBestPlayers()
    {
        global::Database user = new global::Database();
        IDataReader reader = user.DBSelect("Scores", new string[] { "Us.login", "Sc.game_time" }, new string[] { }, new string[] { }, new string[] { "Users", "Levels" }, "Sc.game_time ASC LIMIT 10");
        string logins = "";
        string times = "";
        
        while (reader.Read())
        {
            logins += reader.GetString(0)  + "\n";
            times += reader.GetString(1) + "\n";
        }

        playersLogin.text = logins;
        playersTime.text = times;
    }

    //@TODO
    private void RankOfLoggedPlayer()
    {
        global::Database user = new global::Database();
        //IDataReader reader = user.DBSelect("Scores", new string[] { "Us.login", "Sc.game_time" }, new string[] { }, new string[] { }, new string[] { "Users", "Levels" }, "Sc.game_time ASC LIMIT 10");
        
    }
}
