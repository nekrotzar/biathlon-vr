using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;


public class ScoreManager : MonoBehaviour {

    // String to display time
    public Text timeText;

    // The amount of time that has elapsed
    private float elapsedTime;

	// Use this for initialization
	void Start () {
        elapsedTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        var t = Time.time - elapsedTime;

        timeText.text = FormatTime(t);
	}

    string FormatTime(float time){
        TimeSpan t = TimeSpan.FromSeconds(time);

        return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Minutes, t.Seconds, (t.Milliseconds / 10));
    }
}
