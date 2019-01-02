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

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
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
