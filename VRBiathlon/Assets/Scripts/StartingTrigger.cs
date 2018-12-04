using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTrigger : MonoBehaviour {

    public StagesManager stM;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            stM.startMode = false;
            stM.raceMode = true;            
        }
    }
}
