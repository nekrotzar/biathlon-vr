using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{

    public Transform vrCamera;

    public float toggleAngle = 45.0f;

    public float speed = 3.0f;

    public bool moveforward;

    public bool movebackward;

    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = vrCamera.localEulerAngles.x;
        // Convert angle to negative values
        angle = (angle > 180) ? angle - 360 : angle;


        if (angle >= toggleAngle && angle < 90.0f)
        {
            moveforward = true;
        }
        else if (angle <= -toggleAngle && angle > -90.0f)
        {
            movebackward = true;
        }
        else {
            moveforward = false;
            movebackward = false;
        }

        if (moveforward == true)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        } 
        else if (movebackward == true)
        {
            Vector3 backward = vrCamera.TransformDirection(Vector3.back);
            cc.SimpleMove(backward * speed);
        }
    }
}
