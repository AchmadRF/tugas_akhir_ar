using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject rotate;
    public GameObject targetObject;
    private Camera cam;
    private Vector3 curVec;

    public float rotateSpeed = 50f;
    [SerializeField]
    private bool isRotate;
    private void Start()
    {
        
        cam = Camera.main;
        curVec = GetComponent<Vector3>();
    }

    public void RotateNormal()
    {
        isRotate = !isRotate;
        /*if (!isRotate)
        {
            isRotate = true;
        }
        else
        {
            isRotate = false;
        }*/
    }
    public void RotateToObject()
    {
        isRotate = !isRotate;
        if (isRotate)
        {
            Quaternion currentRotation = rotate.transform.rotation;

            // Get the y-axis rotation of the target object
            Quaternion targetYRotation = Quaternion.Euler(0, 0, targetObject.transform.rotation.z);

            // Create a new rotation that matches the y-axis rotation of the target object
            Quaternion targetRotation = currentRotation * Quaternion.Inverse(currentRotation) * targetYRotation * currentRotation;

            // Set the object's rotation to the target rotation
            rotate.transform.rotation = targetRotation;
        }
    }
    /*private void Update()
    {
        *//*RotateWithMouse(curVec);*//*
        if (isRotate)
        {
            Quaternion currentRotation = rotate.transform.rotation;

            // Get the y-axis rotation of the target object
            Quaternion targetYRotation = Quaternion.Euler(0, 0,targetObject.transform.rotation.z);

            // Create a new rotation that matches the y-axis rotation of the target object
            Quaternion targetRotation = currentRotation * Quaternion.Inverse(currentRotation) * targetYRotation * currentRotation;

            // Set the object's rotation to the target rotation
            rotate.transform.rotation = targetRotation;
        }
    }*/

    private void RotateWithMouse(Vector3 vec)
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.y, cam.nearClipPlane));

        // Calculate the direction to the mouse position
        vec = mousePosition - transform.position;

        // Remove any movement in the z-axis
        vec.z = 0;

        // Calculate the rotation to face the mouse position
        Quaternion targetRotation = Quaternion.LookRotation(vec, Vector3.up);

        // Set the object's rotation to the target rotation
        transform.rotation = targetRotation;
    }
}
