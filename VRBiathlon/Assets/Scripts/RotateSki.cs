using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSki : MonoBehaviour {

    public Transform playerTransf;
    public Transform camTransf;
    public Vector3 rot;

    // Update is called once per frame
    void Update()
    {
        rot.Set(transform.localEulerAngles.x, camTransf.localEulerAngles.y, transform.localEulerAngles.z);
        transform.localEulerAngles = rot;
    }
}
