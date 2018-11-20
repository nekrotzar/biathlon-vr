using System.Collections;
using UnityEngine;

public class StagesManager : MonoBehaviour {

    public GameObject Player;
    public GameObject startPoint;
    public GameObject shootPoint;

    public bool startMode;
    public bool raceMode;
    public bool shootMode;

    private VRLookWalk canWalk;
    private VRShoot canShoot;
    private VRLookGrab canGrab;
    private ScoreManager scrM;
    
	// Use this for initialization
	void Start () {
        startMode = true;
        raceMode = false;
        shootMode = false;

        scrM = GetComponent<ScoreManager>();
   
        canWalk = Player.GetComponent<VRLookWalk>();
        canWalk.enabled = true;
        
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
            scrM.IsRacing(true);
        }

        if(!startMode && !raceMode && shootMode)
        {
            shootPoint.SetActive(false);
            scrM.IsRacing(false);
            canGrab.enabled = true;
            canShoot.enabled = true;
        }
	}
}
