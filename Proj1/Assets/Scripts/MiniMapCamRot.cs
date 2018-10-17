using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamRot : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject player;
    private Transform _mainCTtransf;

	// Use this for initialization
	void Start () {
        _mainCTtransf = mainCamera.transform;
	}
	
	// Update is called once per frame
	void Update () {
        //temp.position.Set(_mainCTtransf.position.x, this.transform.position.y, _mainCTtransf.position.z);
        this.transform.LookAt(mainCamera.transform);
    }
}
