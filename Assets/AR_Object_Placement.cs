using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_Object_Placement : MonoBehaviour
{
    public GameObject AR_Object;
    public GameObject Indicator;
    private GameObject Spawned_AR;

    private Pose pose;
    private ARRaycastManager AR_Raycast_Manager;
    private bool Placement_Valid = false;
    // Start is called before the first frame update
    void Start()
    {
        AR_Raycast_Manager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Spawned_AR == null && Placement_Valid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlacingAR();
        }

        UpdatePose();
        UpdateIndicator();
    }

    void UpdateIndicator()
    {
        if (Spawned_AR == null && Placement_Valid)
        {
            Indicator.SetActive(true);
            Indicator.transform.SetPositionAndRotation(pose.position, pose.rotation);
        }
        else
        {
            Indicator.SetActive(false);
        }
    }

    void UpdatePose()
    {
        var Screen = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        AR_Raycast_Manager.Raycast(Screen, hits, TrackableType.Planes);

        Placement_Valid = hits.Count > 0;
        if (Placement_Valid)
        {
            pose = hits[0].pose;
        }
    }

    void PlacingAR()
    {
        Spawned_AR = Instantiate(AR_Object, pose.position, pose.rotation);
    }
}
