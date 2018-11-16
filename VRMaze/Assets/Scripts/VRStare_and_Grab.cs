using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRStare_and_Grab : MonoBehaviour {

    //public float wait_time = 3.0f;

    public Transform VRHand;
    public Rigidbody TargetObject;

    private float stare_time = 1f; // timer 

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        stare_time = stare_time + Time.deltaTime;
        TargetObject.angularVelocity = Vector3.zero;
        if (stare_time >= 3f) // once a certain amount of time has passed, the object will be 'grabbed'
        {
            GrabObject();
        }
	}

    public void ResetStareTime()
    {
        stare_time = 1f;
    }

    public void GrabObject()
    {
        TargetObject.transform.SetParent(VRHand.transform);
        TargetObject.transform.localPosition = new Vector3(0.0f,0.0f,0.0f);
        TargetObject.transform.localRotation = VRHand.transform.localRotation;
        
        
    }
}
