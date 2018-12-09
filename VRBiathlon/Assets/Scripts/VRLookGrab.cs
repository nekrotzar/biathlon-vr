using UnityEngine;
using UnityEngine.UI;
public class VRLookGrab : MonoBehaviour
{
    public float timer;
    public Transform CircleLoading;
    public Transform VRHand;
    public Rigidbody Riffle;
    public Image dot;
    public Image crosshair;
    private bool _holding;
    // Use this for initialization
    void Start()
    {
        timer = 0;
        _holding = false;
        CircleLoading.GetComponent<Image>().fillAmount = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_holding)
        {
            timer += Time.deltaTime;
            CircleLoading.GetComponent<Image>().fillAmount = timer / 2;
            if (timer >= 2f)
            {
                _holding = true;
                grabObj();
            }
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
        dot.enabled = false;
        crosshair.enabled = true;

    }
}
