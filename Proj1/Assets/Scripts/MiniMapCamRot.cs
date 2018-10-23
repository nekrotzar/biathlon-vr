using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamRot : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject player;
	
	// Update is called once per frame
	void Update () {

        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, mainCamera.transform.eulerAngles.y, this.transform.eulerAngles.z);
        //this.transform.LookAt(mainCamera.transform);
    }
}
