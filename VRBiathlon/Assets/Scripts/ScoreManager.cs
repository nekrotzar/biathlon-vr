using System;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // String to display time
    public Text timeText;
    public Text ammoText;
    private int _ammoleft = 0;

    public float timePenalty = 10;
    private float elapsedTime;
    private bool _running;
    private bool _shooting;
    private bool _final;
    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        _running = false;
        _shooting = false;
        elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_running)
        {
            elapsedTime += Time.deltaTime;
            timeText.text = FormatTime(elapsedTime);
        }
        if (_shooting)
        {
            ammoText.text = "Ammo:" + _ammoleft;
        }
        if(_final)
        {
            timeText.text = "Final Score : " + FormatTime(elapsedTime);
            ammoText.gameObject.SetActive(false);
        }
        
    }

    string FormatTime(float time)
    {
        TimeSpan t = TimeSpan.FromSeconds(time);

        return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Minutes, t.Seconds, (t.Milliseconds / 10));
    }

    public void ApplyTimePenalty()
    {
        elapsedTime += timePenalty;
        timeText.text = FormatTime(elapsedTime);
    }

    //If 1 - start the race, if 0 - race ended
    public void IsRacing(bool state)
    {
        _running = state;
    }

    public void IsShooting(bool state)
    {
        _shooting = state;
    }

    public void AmmoLeft (int x)
    {
        _ammoleft = x;
    }

    public void isFinal(bool state)
    {
        _final = state;
    }
}
