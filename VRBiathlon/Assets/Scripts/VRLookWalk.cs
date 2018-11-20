using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle = 45.0f;
    public bool moveforward;
    public bool movebackward;

    private Rigidbody _rgbd;
    private float _nextPush;
    public float pushRate;
    public float pushForce;

    public AudioClip WindSound;
    public AudioSource WindSource;
    public AudioClip SkiingSound;
    public AudioSource SkiingSource;

    // Use this for initialization
    void Start()
    {
        WindSource.clip = WindSound;
        SkiingSource.clip = SkiingSound;
        WindSource.Play();
        WindSource.loop = true;
        _rgbd = GetComponent<Rigidbody>();
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
            //SkiingSource.Stop();
        }
        else
        {
            moveforward = false;
            movebackward = false;
        }

        if (moveforward == true && Input.GetButtonDown("Fire1") && Time.time > _nextPush)
        {
            SkiingSource.Play();
            
            _nextPush = Time.time + pushRate;
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            _rgbd.AddForce(forward * pushForce, ForceMode.Impulse);
        }
    }
}
