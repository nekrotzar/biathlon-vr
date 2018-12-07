using UnityEngine;
using UnityEngine.UI;

public class VRGazeClick : MonoBehaviour
{
    public float gazeTime;
    public Button btn;
    public Slider statusSlider;

    private float timer;
    private bool clicked;

    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!clicked)
        {
            timer += Time.deltaTime;

            statusSlider.normalizedValue += Time.deltaTime / gazeTime;

            if (timer >= gazeTime)
            {
                clicked = true;
                clickButton();
            }
        }
    }

    public void ResetTime()
    {
        timer = 0.0f;
        statusSlider.normalizedValue = 0.0f;
    }

    public void clickButton()
    {
        btn.onClick.Invoke();
    }
}
