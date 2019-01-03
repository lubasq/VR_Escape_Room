using System.Collections;
using System.Collections.Generic;
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
    private string minutes;
    private string seconds;
    private float delayTime;

    void Start()
    {
        delayTime = 2;
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
        {
            doorTimer.text = minutes + "m " + seconds + "s";
            pauseTimer.text = minutes + "m " + seconds + "s";
            endTimer.text = minutes + "m " + seconds + "s";
        }
        else
        {
            doorTimer.text = seconds + "s";
            pauseTimer.text = seconds + "s";
            endTimer.text = seconds + "s";
        }
    }
}
