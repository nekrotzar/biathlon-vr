using UnityEngine;

public class VRShoot : MonoBehaviour {

    public float range = 100f;
    public float shotRate;
    private float _nextShot = 1f;
    public bool _missedShot;

    public Camera mainCamera;
    public AudioClip SoundClip;
    public AudioSource SoundSource;
    
    public ParticleSystem flash;
    public GameObject metalImpactEffect;
    public GameObject snowImpactEffect;

    public ScoreManager _scM;

    void Start()
    {
        _missedShot = false;
        SoundSource.clip = SoundClip;
    }
    // Update is called once per frame
    void Update () {
		//stil need to add joystick input  
        if((Input.GetMouseButtonDown(0) || (Input.GetButtonDown("Fire2"))) && Time.time > _nextShot)
        {
            _nextShot = Time.time + shotRate;
            SoundSource.Play();
            Shoot();
        }
	}

    void Shoot()
    {
        RaycastHit hit;

        flash.Play();

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Target")
            {
                Renderer rend = hit.transform.GetComponent<Renderer>();

                rend.material.shader = Shader.Find("_Color");
                rend.material.SetColor("_Color", Color.white);

                rend.material.shader = Shader.Find("Specular");
                rend.material.SetColor("_SpecColor", Color.white);

                Instantiate(metalImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            } 
            else
            {
                // Increase elapsed time when the shot misses
                _scM.ApplyTimePenalty();
                Instantiate(snowImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }

        }
        else 
        {
            // Increase elapsed time when the shot misses
            _scM.ApplyTimePenalty();
        }
    }
}
