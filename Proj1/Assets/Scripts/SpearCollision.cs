using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollision : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.tag == "Dragon") {
			col.gameObject.SetActive (false);
		}
    }
}
