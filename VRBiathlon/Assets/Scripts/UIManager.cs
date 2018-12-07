using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

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
        GameManager.instance.StartEvent();
        Debug.Log("Star game");
    }

    void StartSkiClick()
    {
        optionPressed = true;
        GameManager.instance.StartSki();
        Debug.Log("Star ski");
    }

    void StartShootClick()
    {
        optionPressed = true;
        GameManager.instance.StartShooting();
        Debug.Log("Star shooting here");
    }
}
