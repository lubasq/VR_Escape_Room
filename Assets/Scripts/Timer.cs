using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text doorTimer;
    [SerializeField] private TMP_Text pauseTimer;
    [SerializeField] private TMP_Text endTimer;
    private float startTime;
    private float startTime1;
    private bool delay = true;
    private float t;
    private static string hours="00";
    private static string minutes;
    private static string seconds;
    private float delayTime;
    string timeDB = string.Format("{0:D2}:{1:D2}:{2:D2}",hours, minutes, seconds);

    void Start()
    {
        delayTime = 0;//Set delay time here
        startTime = Time.time;
        startTime1 = Time.time + delayTime;
    }

    void Update()
    {
        
        if (delay)
        {
            t = Time.time - startTime;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f0");
            if (seconds == delayTime.ToString())
            {
                delay =! delay;
            }
        } else
        {
            t = Time.time - startTime1;
            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f0");
        }

        if (t >= 60)
        {       doorTimer.text = minutes + "m " + seconds + "s";
                pauseTimer.text = minutes + "m " + seconds + "s";
                endTimer.text = minutes + "m " + seconds + "s";
        }
        else
        {
                doorTimer.text = seconds + "s";
                pauseTimer.text = seconds + "s";
                endTimer.text = seconds + "s";            
        }
        if (Mathf.Round(t % 60) < 10)
        {
            seconds = "0" + seconds;
        }
        if (Mathf.Round(t / 60) < 10)
        {
            minutes = "0" + minutes;
        }
        timeDB = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        //Debug.Log(timeDB);
    }

    public void SaveScoreToDB()
    {
        
        string id = PlayerPrefs.GetInt("id").ToString();
        global::Database doDB = new global::Database();        

        if (doDB.DBInsert("Scores", new string[] { "game_date", "game_time", "Users_id_user", "Levels_id_level" }, new string[] { System.DateTime.Now.ToString("yyyy-MM-dd"), timeDB, id ,"1" })) 
        {
            Debug.Log("Score saved");
        }
        else
        {
            Debug.Log("Score saving doesn't work");
        }
        doDB.DBClose();
        doDB = null;
        
    }
}
