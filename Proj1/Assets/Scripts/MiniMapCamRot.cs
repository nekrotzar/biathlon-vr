using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamRot : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject player;
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(mainCamera.transform);
    }
}
