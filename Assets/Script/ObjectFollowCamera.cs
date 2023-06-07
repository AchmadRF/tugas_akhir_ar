using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFollowCamera : MonoBehaviour
{
    public CollisionDetection collide;
    [System.Serializable]
    public struct ObjectData
    {
        public GameObject targetObject;
        public Button targetButton;
        public Vector3 curPos;
    }

    public Camera cam; // Reference to the Camera
    public ObjectData[] objectDatas; // Array of ObjectData
    private GameObject selectedObject; // The currently selected object

    private Plane movePlane;
    public float speed;
    public float distanceFromCamera;
    void Start()
    {
        movePlane = new Plane(Vector3.forward, transform.position);
        

        // For each ObjectData, add a listener to the button's onClick event
        foreach (var data in objectDatas)
        {
            data.targetButton.onClick.AddListener(() => SelectObject(data.targetObject));
        }
    }

    void Update()
    {
        // If an object is selected, move and possibly rotate it
        if (selectedObject != null)
        {
            MoveObject(selectedObject, collide.isCollided);
        }

    }
    private void SelectObject(GameObject objectToMove)
    {
        selectedObject = objectToMove;
        collide.isCollided = false;
        Debug.Log(collide.isCollided);
        /* if (!collide.isCollided)
         {
             selectedObject = objectToMove;
             Debug.Log(collide.isCollided);
             toggleCounter = 1;
         }else if (collide.isCollided)
         {
             collide.isCollided = false;
         }*/

        // When a button is pressed, set the selected object to the corresponding object
    }
    
    private void MoveObject(GameObject objectToMove, bool isMove)
    {
        /*Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        // Apply the new position to the object, but keep the original z coordinate
        objectToMove.transform.position = new Vector3(worldPos.x, worldPos.y, objectToMove.transform.position.z);*/

        // Create a ray from the mouse cursor on screen in the direction of the camera.
        /*Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Perform the raycast and if it hits something, move the game object to the hit point
        if (movePlane.Raycast(ray, out float distance))
        {

            Vector3 worldPos = ray.GetPoint(distance);
            // Move the object to the hit point
            objectToMove.transform.position = new Vector3(worldPos.x, worldPos.y, 34.55674f);
        }*/

        Vector3 movement = Vector3.zero;
        // Speed of the movement

        /*foreach (ObjectData targetObject in objectDatas)
        {
            if (targetObject.targetObject.CompareTag("KabelPositif"))
            {
                collide.isCollidedObjectA = isMove;
            }
            else if (targetObject.targetObject.CompareTag("KabelNegatif"))
            {
                collide.isCollidedObjectB = isMove;
            }

            if(Input.GetKey(KeyCode.A))
            {
                if (isMove)
                {
                    movement += Vector3.left * speed * Time.deltaTime;
                }
            }
            else if(Input.GetKey(KeyCode.D))
            {
                if (isMove)
                {
                    movement += Vector3.right * speed * Time.deltaTime;
                }
                Debug.Log(isMove);
            }
        }*/
        // Check if the A key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            if (!isMove)
            {
                movement += Vector3.left * speed * Time.deltaTime;
            }

            // Move left along the x-axis
        }

        // Check if the D key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            if (!isMove)
            {
                movement += Vector3.right * speed * Time.deltaTime;
            }

            // Move right along the x-axis
        }

        // Apply the movement to the current position of the selected object
        objectToMove.transform.position += movement;
    }

    public void AnchorCamera()
    {
        ObjectData targetObj = Array.Find(objectDatas, data => data.targetObject.gameObject.name == "Rangkaian");
        if(targetObj.targetObject != null)
        {
            targetObj.targetObject.transform.position = cam.transform.position + cam.transform.forward * distanceFromCamera;
            targetObj.targetObject.transform.LookAt(cam.transform);
        }
        // Optionally, make the object always face the camera
        
    }
}


