using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // A public static reference to itself allows all other objects in the game access to it. 
    public static GameManager instance;

    public GameObject Player;
    public GameObject startPoint;
    public GameObject shootPoint;
    
    public bool startMode;
    public bool raceMode;
    public bool shootMode;

    private VRLookWalk canWalk;
    private VRShoot canShoot;
    private VRLookGrab canGrab;

    private ScoreManager scoreManager;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        startMode = true;
        raceMode = false;
        shootMode = false;


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
        if(!startMode && raceMode && !shootMode)
        {
            startPoint.SetActive(false);
            scoreManager.IsRacing(true);
        }

        if(!startMode && !raceMode && shootMode)
        {
            shootPoint.SetActive(false);
            scoreManager.IsRacing(false);
            canGrab.enabled = true;
            canShoot.enabled = true;
            canWalk.enabled = false;
            Player.GetComponent<Rigidbody>().drag = 2;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Restart();
        }
	}

    public void StartEvent()
    {
        canWalk.enabled = true;
    }

    public void StartSki()
    {
        canWalk.enabled = true;
        scoreManager.IsRacing(true);
    }

    public void StartShooting()
    {
        this.Player.transform.position = shootPoint.transform.position;
        canShoot.enabled = true;
        canWalk.enabled = false;
    }

    public void Restart()
    {
        //Restart the scene by loading the scene that is currently loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
