using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scaler : MonoBehaviour
{
    private Slider RotateSliderX;
    private Slider RotateSliderY;
    public float RotateXMin;
    public float RotateXMax;
    public float RotateYMin;
    public float RotateYMax;

    Vector3 CurrentEulerAngles;
    // Start is called before the first frame update
    void Start()
    {
        RotateSliderX = GameObject.Find("Slider_X").GetComponent<Slider>();
        RotateSliderX.minValue = RotateXMin;
        RotateSliderX.maxValue = RotateXMax;

        RotateSliderX.onValueChanged.AddListener(XUpdate);

        RotateSliderY = GameObject.Find("Slider_Y").GetComponent<Slider>();
        RotateSliderY.minValue = RotateYMin;
        RotateSliderY.maxValue = RotateYMax;

        RotateSliderY.onValueChanged.AddListener(YUpdate);
    }

    // Update is called once per frame
    void XUpdate(float value)
    {
        CurrentEulerAngles += new Vector3(value, transform.rotation.y, transform.rotation.z) * Time.deltaTime;
        transform.eulerAngles = CurrentEulerAngles;
    }

    void YUpdate(float value)
    {
        CurrentEulerAngles += new Vector3(transform.rotation.y, value, transform.rotation.z) * Time.deltaTime;
        transform.eulerAngles = CurrentEulerAngles;
    }
}
