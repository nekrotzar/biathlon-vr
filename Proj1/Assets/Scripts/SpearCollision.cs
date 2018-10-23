using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollision : MonoBehaviour {

    public Animator animator;

    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "Dragon") {
			//col.gameObject.SetActive (false);

            animator.SetTrigger("Dragon_isDead");
            col.gameObject.GetComponent<Collider>().enabled = false;
		}
    }
}
