using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;


public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance = null; // Static instance accessible from any other script

    // String to display time
    public Text timeText;
    public float timePenalty = 10;
    
    private float elapsedTime;

    void Awake(){
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        elapsedTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        timeText.text = FormatTime(elapsedTime);
	}

    string FormatTime(float time){
        TimeSpan t = TimeSpan.FromSeconds(time);

        return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Minutes, t.Seconds, (t.Milliseconds / 10));
    }

    public void ApplyTimePenalty(){
        elapsedTime += timePenalty;
    }
}
