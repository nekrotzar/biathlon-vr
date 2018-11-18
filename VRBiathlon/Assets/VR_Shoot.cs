using UnityEngine;

public class VR_Shoot : MonoBehaviour {

    public float range = 100f;
    public Camera mainCamera;
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
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
