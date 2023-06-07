using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    /*    public ObjectFollowCamera objectFollow; 
        public GameObject parentObject;*/
    public GameObject statusWindow;
    // The parent object whose children we're checking for collisions
    public bool isCollidedObjectA;
    public bool isCollidedObjectB;
    public bool isCollided;
    private Vector3 thisPos;

    private void Start()
    {
        /*thisPos = CollisionNotifier.Instance.curPos;
        Debug.Log(thisPos);*/
        Rigidbody rigid = (Rigidbody)FindObjectOfType(typeof(Rigidbody));
        if (rigid)
        {
            Debug.Log($"RigidBody object found : + {rigid.name}");
        }
    }

    public void NotifyCollisionEnter(GameObject self, GameObject other)
    {
        isCollided = true;
        if (self.gameObject.CompareTag("KabelPositif"))
        {
            isCollidedObjectA = isCollided;
            if (isCollidedObjectA)
            {
                SnippetPositionObject(self, other);
                Debug.Log($"{self.name} collided with {other.name} !");
            }
        }
         else if (self.gameObject.CompareTag("KabelNegatif"))
        {
            isCollidedObjectB = isCollided;
            if (isCollidedObjectB)
            {
                SnippetPositionObject(self, other);
                Debug.Log($"{self.name} collided with {other.name} !");
            }
        }
        
        if (isCollidedObjectA && isCollidedObjectB)
        {
            ShowStatusWindows();
        }
    }

    public void NotifyCollisionExit(GameObject self, GameObject other)
    {
/*        thisPos = CollisionNotifier.Instance.curPos;
        
        Debug.Log(CollisionNotifier.Instance.curPos);*/
        isCollided = false;
        if (self.gameObject.CompareTag("KabelPositif"))
        {
            isCollidedObjectA = isCollided;
            if (!isCollidedObjectA)
            {
                /*BackToOriginPos(self);*/
                Debug.Log($"{self.name} not collided with {other.name} !");
            }
        }else if (self.gameObject.CompareTag("KabelNegatif"))
        {
            isCollidedObjectB = isCollided;
            if (!isCollidedObjectB)
            {
                /*BackToOriginPos(self);*/
                Debug.Log($"{self.name} not collided with {other.name} !");
            }
        }
        if (!isCollidedObjectA || !isCollidedObjectB)
        {
            HideStatusWindows();
        }
    }

    public void ShowStatusWindows()
    {
        statusWindow.SetActive(true);
    }
    public void HideStatusWindows()
    {
        statusWindow.SetActive(false);
    }
    private void BackToOriginPos(GameObject self)
    {
        if (CollisionNotifier.Instance.curPos != null)
        {
            self.transform.position = CollisionNotifier.Instance.curPos;
        }
    }
    public void SnippetPositionObject(GameObject self, GameObject other)
    {
        self.transform.position = other.transform.position;
    }


    /* void OnTriggerEnter(Collider other)
     {
         if (other.gameObject == collisionObject1)
         {
             Debug.Log("Collided A");
         }
         else if (other.gameObject == collisionObject2)
         {
             Debug.Log("Collided B");
         }
         string parentTag = parentObject.gameObject.tag;

         foreach (var data in objectFollow.objectDatas)
         {
             if (other.CompareTag(data.targetObject.tag))
             {
                 if (other.transform.IsChildOf(parentObject.transform))
                 {
                     // Collision detected, do something...
                     Debug.Log("Collision detected with " + other.gameObject.name);
                 }
             }
         }
     }*/
}
