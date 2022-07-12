using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class AR_Placement : MonoBehaviour
{
    [SerializeField]
    public GameObject AR_Prefab;

    private GameObject spawned_Prefab;
    private ARRaycastManager aRRaycastManager;
    private Vector2 touchPos;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>() ;
    // Start is called before the first frame update
    private void Awake()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool GetTouchPos(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(index: 0).position;
            return true;
        }
        touchPos = default;
        return false;
            
    }
    // Update is called once per frame
    private void Update()
    {
        if(!GetTouchPos(out Vector2 touchPos))
        {
            return;
        }
        if(aRRaycastManager.Raycast(touchPos, hits, trackableTypes: TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if(spawned_Prefab == null)
            {
                spawned_Prefab = Instantiate(AR_Prefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawned_Prefab.transform.position = hitPose.position;
            }
        }
    }
}
