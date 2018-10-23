using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollision : MonoBehaviour {

    public Animator animator;
    public ParticleSystem ps;
    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "Dragon") {
			col.gameObject.SetActive (false);

            Instantiate(ps);
            /*
            GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;
            */
            /*
            animator.SetTrigger("Dragon_isDead");
            col.gameObject.GetComponent<Collider>().enabled = false;
            */
        }
    }
}
