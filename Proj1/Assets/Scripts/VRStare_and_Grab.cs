using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRStare_and_Grab : MonoBehaviour {

    public float stare_time = 0f; // timer 
    public Transform VRHand;
    public Rigidbody TargetObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        stare_time = stare_time + Time.deltaTime;

        if (stare_time >= 3f) // once a certain amount of time has passed, the object will be 'grabbed'
        {
            GrabObject();
        }
	}

    public void ResetStareTime()
    {
        stare_time = 0f;
    }

    public void GrabObject()
    {
        TargetObject.transform.parent = VRHand.transform;
    }
}
