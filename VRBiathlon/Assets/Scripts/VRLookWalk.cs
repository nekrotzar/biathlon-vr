using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle = 45.0f;
    public float speed = 10f, lateralSpeed = 0.5f, maxSpeed = 10f;
    //public float timeMaxToZero = 3f, timeZeroToMax = 0.5f;
    public bool moveforward;
    public bool movebackward;
    //float accelRate;
    //float decelRate;
    //float forwardVelocity;

    private Rigidbody _rgbd;
    private float _nextPush;
    public float pushRate;
    public float pushForce;
    //private Vector3 zeroy;
    private Vector3 localRot;
    //private Vector3 gravity = new Vector3 (0,-1,0);

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
        /*
        accelRate = maxSpeed / timeZeroToMax;
        decelRate = -maxSpeed / timeMaxToZero;
        forwardVelocity = 0f;
        */
    }

    // Update is called once per frame
    void Update()
    {
        float angle = vrCamera.localEulerAngles.x;
        float angle2 = vrCamera.rotation.eulerAngles[2];
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

        if (Input.GetButtonDown("Fire1") && Time.time > _nextPush)
        {
            SkiingSource.Play();
            //_rgbd.MovePosition(_rgbd.position + new Vector3(0, 0, 1) * speed * Time.fixedDeltaTime - new Vector3(1, 0, 0) * angle * lateralSpeed * Time.fixedDeltaTime);
            
            /*
            forwardVelocity += accelRate * Time.deltaTime;
            forwardVelocity = Mathf.Min(forwardVelocity, maxSpeed);
            zeroy = vrCamera.transform.forward;
            zeroy.y = 0;

            _rgbd.velocity = zeroy * forwardVelocity;

            localRot = transform.localRotation.eulerAngles;
            localRot.z = 0;
            transform.localRotation = Quaternion.Euler(localRot);
            */
            
            _nextPush = Time.time + pushRate;
            
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            forward.y = 0;
            _rgbd.AddForce(forward * pushForce, ForceMode.Impulse);

            localRot = transform.localRotation.eulerAngles;
            localRot.z = 0;
            transform.localRotation = Quaternion.Euler(localRot);


        }
        /*
       else{
            forwardVelocity += decelRate * Time.deltaTime;
            forwardVelocity = Mathf.Max(forwardVelocity, 0);
            
            _rgbd.velocity = vrCamera.transform.forward * forwardVelocity + gravity;
            
            
        }
        */
        
    }
}
