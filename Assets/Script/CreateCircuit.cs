using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCircuit : MonoBehaviour
{
    public bool onCreated;
    public GameObject obj1, obj2, objToBeDestroy;
    public Button create1, create2;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vecObj1 = new Vector3(obj1.transform.localPosition.x, obj1.transform.localPosition.y, obj1.transform.localPosition.z);
        Debug.Log(vecObj1);
    }

    public void _CreateCircuit(int index)
    {
        onCreated = true;
        if (onCreated)
        {
            if (index == 1)
            {
                create2.interactable = false;
                Vector3 vecObj1 = new Vector3(obj1.transform.localPosition.x, obj1.transform.localPosition.y, obj1.transform.localPosition.z);
                objToBeDestroy = Instantiate(obj1, vecObj1, Quaternion.identity);
            }
            if (index == 2)
            {
                create1.interactable = false;
                Vector3 vecObj2 = new Vector3(obj2.transform.localPosition.x, obj1.transform.localPosition.y, obj1.transform.localPosition.z);
                objToBeDestroy = Instantiate(obj2, vecObj2, Quaternion.identity);
            }
        }
        
    }
    public void DestroyObj()
    {
        Destroy(objToBeDestroy);
        create1.interactable = true;
        create2.interactable = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
