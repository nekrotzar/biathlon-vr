using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrigger : MonoBehaviour {

    public GameManager GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.raceMode = false;
            GameManager.startMode = false;
            if(!GameManager.skiMode)
            {
                GameManager.shootMode = true;
            }
        }
    }
}
