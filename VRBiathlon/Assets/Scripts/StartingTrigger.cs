using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTrigger : MonoBehaviour {

    public GameManager GameManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player passed");
            if (!GameManager.skiMode)
            {                
                GameManager.scoreManager.IsRacing(true);
            }             
        }
    }
}
