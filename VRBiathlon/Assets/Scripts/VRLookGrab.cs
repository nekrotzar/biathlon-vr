using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VRLookGrab : MonoBehaviour
{
    public float timer = 0f;
    public Transform CircleLoading;
    public Transform VRHand;
    public Rigidbody Riffle;

    // Use this for initialization
    void Start()
    {
        CircleLoading.GetComponent<Image>().fillAmount = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        CircleLoading.GetComponent<Image>().fillAmount = timer / 2;
        if (timer >= 2f)
        {
            grabObj();
        }
    }

    public void ResetTime()
    {
        timer = 0f;
        CircleLoading.GetComponent<Image>().fillAmount = timer;
    }

    public void grabObj()
    {
        Riffle.transform.localRotation = VRHand.transform.rotation;
        Riffle.transform.parent = VRHand.transform;

        Riffle.transform.localPosition = new Vector3(-8f, -4f, 4f);
    }
}
