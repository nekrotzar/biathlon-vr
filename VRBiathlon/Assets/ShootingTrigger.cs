using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrigger : MonoBehaviour {

    public StagesManager stM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stM.raceMode = false;
            stM.shootMode = true;
        }
    }
}
