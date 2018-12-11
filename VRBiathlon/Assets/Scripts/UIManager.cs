using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameManager GameManager;

    [Header("Main menu buttons")]
    public Button eventModeBtn;
    public Button skiModeBtn;
    public Button shootModeBtn;

    public GameObject mainMenu;
    public CanvasGroup menuCG;

    private bool optionPressed;

    // Use this for initialization
    void Start () {

        optionPressed = false;

        eventModeBtn.onClick.AddListener(StartEventClick);
        skiModeBtn.onClick.AddListener(StartSkiClick);
        shootModeBtn.onClick.AddListener(StartShootClick);
    }

    void Update()
    {
        if (optionPressed)
            menuCG.alpha -= Time.deltaTime;

        // Check if menu has disapeared
        if (menuCG.alpha <= 0)
        {
            mainMenu.SetActive(false);
        }
    }

    void StartEventClick()
    {
        optionPressed = true;
        GameManager.StartEvent();
        Debug.Log("Start game");
    }

    void StartSkiClick()
    {
        optionPressed = true;
        GameManager.StartSki();
        Debug.Log("Start ski");
    }

    void StartShootClick()
    {
        optionPressed = true;
        GameManager.StartShooting();
        Debug.Log("Start shooting here");
    }
}
