using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class Rank : MonoBehaviour {
    public TMP_Text playersLogin;
    public TMP_Text playersTime;
    public TMP_Text loggedPlayerPosition;
    public TMP_Text loggedPlayerTime;
    public static string localLogin;
    public TMP_Text loggedPlayerLogin;

    // Use this for initialization
    void Start () {
        RankOfBestPlayers();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void RankOfBestPlayers()
    {
        localLogin = Login.loginText;
        global::Database user = new global::Database();
        IDataReader reader = user.DBSelect("Scores", new string[] { "Us.login", "Sc.game_time" }, new string[] { }, new string[] { }, new string[] { "Users", "Levels" }, "Sc.game_time ASC LIMIT 10");
        string logins = "";
        string times = "";
        
        while (reader.Read())
        {
            logins += reader.GetString(0)  + "\n";
            times += reader.GetString(1) + "\n";
        }

        if (!logins.Contains(localLogin))
        {
            Debug.Log(localLogin);
            RankOfLoggedPlayer(localLogin);
        }

        playersLogin.text = logins;
        playersTime.text = times;
    }

    //@TODO
    private void RankOfLoggedPlayer(string username)
    {
        global::Database user = new global::Database();
        IDataReader reader = user.DBSelect("Scores", new string[] { "(SELECT count(*) FROM Scores Sc1 WHERE Sc.game_time >= Sc1.game_time) AS Position", "Sc.game_time" }, new string[] {"Us.login"}, new string[] {username}, new string[] { "Users", "Levels" }, "Sc.game_time ASC LIMIT 1");
        int position = 0;
        string time = "";

        while (reader.Read())
        {
            position = reader.GetInt32(0);
            time += reader.GetString(1);
        }

        if(position > 0)
        {
            loggedPlayerPosition.text = position.ToString();
            loggedPlayerTime.text = time;
        }
        loggedPlayerLogin.text = Login.loginText;
    }
}
