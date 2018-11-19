﻿using UnityEngine;

public class VR_Shoot : MonoBehaviour {

    public float range = 100f;
    public Camera mainCamera;
    public AudioClip SoundClip;
    public AudioSource SoundSource;
    private float _nextShot;
    public float shotRate;

    void Start()
    {
        SoundSource.clip = SoundClip;
    }
    // Update is called once per frame
    void Update () {
		//stil need to add joystick input  
        if(Input.GetMouseButtonDown(0) && Time.time > _nextShot)
        {
            _nextShot = Time.time + shotRate;
            SoundSource.Play();
            Shoot();
        }

	}

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Target")
            {
                Renderer rend = hit.transform.GetComponent<Renderer>();

                rend.material.shader = Shader.Find("_Color");
                rend.material.SetColor("_Color", Color.white);

                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_SpecColor", Color.white);
            }
        }


    }
}
