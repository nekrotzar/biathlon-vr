using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject startPoint;
    public GameObject shootPoint;
    public Image dot;

    public GameObject raceUI;

    public bool startMode;
    public bool raceMode;
    public bool shootMode;
    public bool skiMode;

    private VRLookWalk canWalk;
    private VRShoot canShoot;
    private VRLookGrab canGrab;

    public ScoreManager scoreManager;


    // Use this for initialization
    void Start () {
        startMode = true;
        raceMode = false;
        skiMode = false;
        shootMode = false;

        raceUI.SetActive(false);

        dot.enabled = true;
        
        scoreManager = GetComponent<ScoreManager>();

        canWalk = Player.GetComponent<VRLookWalk>();
        canWalk.enabled = false;
        
        canShoot = Player.GetComponent<VRShoot>();
        canShoot.enabled = false;

        canGrab = Player.GetComponent<VRLookGrab>();
        canGrab.enabled = false;        
    }
	
	// Update is called once per frame
	void Update () {
        if(raceMode)
        {
            startPoint.SetActive(true);
            shootPoint.SetActive(true);
            canWalk.enabled = true;
        }
        if(skiMode)
        {
            startMode = false;
            startPoint.SetActive(false);
            shootPoint.SetActive(false);
            scoreManager.IsRacing(false);
            canWalk.enabled = true;
        }
        if(shootMode)
        {            
            shootPoint.SetActive(true);
            scoreManager.IsRacing(false);
            canGrab.enabled = true;
            canShoot.enabled = true;
            canWalk.enabled = false;
            Player.GetComponent<Rigidbody>().drag = 2;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            startMode = true;
            Restart();
        }
	}

    public void StartEvent()
    {
        startMode = false;
        Debug.Log("The full run has started!");
        raceMode = true;
        skiMode = false;
        raceUI.SetActive(true);
    }

    public void StartSki()
    {
        startMode = false;
        raceMode = false;
        skiMode = true;
        dot.enabled = true;       
    }

    public void StartShooting()
    {
        startMode = false;
        Player.transform.position = shootPoint.transform.position;    
    }

    public void Restart()
    {
        //Restart the scene by loading the scene that is currently loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
