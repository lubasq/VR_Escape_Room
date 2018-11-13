using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    public TMP_Text timer;
    private float startTime;

    void Start () {
        startTime = Time.time;
    }
	
	void Update () {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        if (t >= 60)
        {
            timer.text = minutes + "m " + seconds + "s";
        }
        else
        {
            timer.text = seconds + "s";
        }
    }
}
