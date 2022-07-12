using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InteractionPoint : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(ARSession.state == ARSessionState.SessionTracking)
        {
            FollowPalmCenter();
        }
    }

    private void FollowPalmCenter()
    {
        HandInfo DetectedHand = ManomotionManager.Instance.Hand_infos[0].hand_info;
        ManoClass DetectedManoClass = DetectedHand.gesture_info.mano_class;

        Vector3 PalmCenterPosition = DetectedHand.tracking_info.palm_center;

        if(DetectedManoClass == ManoClass.GRAB_GESTURE)
        {
            this.transform.position = ManoUtils.Instance.CalculateNewPosition(PalmCenterPosition, DetectedHand.tracking_info.depth_estimation);
        }
    }
}
