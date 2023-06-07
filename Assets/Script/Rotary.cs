using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotary : MonoBehaviour
{
    /*private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    public float rotationSpeed = 1f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                currentTouchPosition = touch.position;
                float difference = startTouchPosition.x - currentTouchPosition.x;
                startTouchPosition = currentTouchPosition;

                transform.Rotate(Vector3.up, difference * rotationSpeed * Time.deltaTime);
            }
        }
    }*/
    /*public GameObject targetObj;
    public float rotationSpeed = 50f;
    private bool rotateRight = true;

    public void ToggleRotation()
    {
        rotateRight = !rotateRight;
    }

    void Update()
    {
        if (rotateRight)
        {
            targetObj.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            targetObj.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
    }*/
    public Text textDebug;
    public GameObject targetObj, targetObj2, targetObj3,targetObj4;
    private Vector3 previousMousePosition;
    private Vector3 newSnapRotation;
    public float rotationSpeed = 10f;
    public float rotationDegree;
    public bool onPressed;
    public bool snapOn;

    private void Start()
    {
        float eulerObj1 = targetObj.transform.localRotation.eulerAngles.y;
        Debug.Log($"Object 1 rotation : {eulerObj1}");
        float eulerObj2 = targetObj2.transform.localRotation.eulerAngles.y;
        Debug.Log($"Object 2 rotation : {eulerObj2}");
        float eulerObj3 = targetObj3.transform.localRotation.eulerAngles.y;
        Debug.Log($"Object 3 rotation : {eulerObj3}");
    }

    

    public void CheckDegree(bool isSnap)
    {
        isSnap = true;
        rotationDegree = targetObj.transform.localRotation.eulerAngles.y;
        /*snapOn = true;*//*snapOn = true;*/
        if (rotationDegree > 30f && rotationDegree <= 45f || rotationDegree <60f)
        {
            float eulerObj2 = targetObj2.transform.localRotation.eulerAngles.y;
            textDebug.text = "Ampere";
            Vector3 currentRotation = targetObj.transform.localRotation.eulerAngles;
            currentRotation.y = eulerObj2;

            targetObj.transform.localEulerAngles = currentRotation;
            Formula.instance.CalculateAmperage(Formula.instance.Voltage, Formula.instance.Resistance);

        }
        if (rotationDegree >= 60f && rotationDegree <= 90f )
        {
            float eulerObj3 = targetObj3.transform.localRotation.eulerAngles.y;
            textDebug.text = "Volt";
            Vector3 currentRotation = targetObj.transform.localRotation.eulerAngles;
            currentRotation.y = eulerObj3;

            targetObj.transform.localEulerAngles = currentRotation;
            Formula.instance.CalculateVoltage(Formula.instance.Current, Formula.instance.Resistance);
        }
        if (rotationDegree < 30f || rotationDegree > 90f)
        {
            float eulerObj4 = targetObj4.transform.localRotation.eulerAngles.y;
            textDebug.text = "Resistance";
            Vector3 currentRotation = targetObj.transform.localRotation.eulerAngles;
            currentRotation.y = eulerObj4;

            targetObj.transform.localEulerAngles = currentRotation;
            Formula.instance.CalculateResistance(Formula.instance.Current, Formula.instance.Voltage);

        }
    }
    void Update()
    {
        if (!snapOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                onPressed = true;
                snapOn = false;
                previousMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 direction = Input.mousePosition - previousMousePosition;
                float rotation = Vector3.Dot(direction, Camera.main.transform.right);

                targetObj.transform.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);

                previousMousePosition = Input.mousePosition;
                Debug.Log(previousMousePosition);
                
            }

            if (Input.GetMouseButtonUp(0))
            {
                onPressed = false;
                snapOn = false;
                if (!onPressed)
                {
                    CheckDegree(snapOn);
                }
                else
                {
                    CheckDegree(!snapOn);
                }
            }

        }

        
    }
}
