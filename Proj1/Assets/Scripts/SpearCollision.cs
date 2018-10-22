using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearCollision : MonoBehaviour {
    public bool isAlive;
    public Animator anim;

	// Use this for initialization
	void Start () {
        isAlive = true;
        anim = GetComponent<Animator>();
        //anim.SetBool("Dragon_isAlive", true);
    }

   

    void OnTriggerEnter(Collider coll)
    {/*
        Debug.Log("olha eu a entrar");
        isAlive = false;
        */
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKey(KeyCode.O))
            anim.SetBool("Dragon_isDead", false);
        else if (Input.GetKey(KeyCode.P))
            anim.SetBool("Dragon_isDead", true);
        /*
        if (isAlive)
            anim.SetBool("Dragon_isDead", false);
        else if (!isAlive)
            anim.SetBool("Dragon_isDead", true);
            */
    }
}
