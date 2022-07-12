using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Clicker : MonoBehaviour
{
    bool isSessionQualityOk;
    // Start is called before the first frame update
    private void Start()
    {
        ARSession.stateChanged += HandleStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSessionQualityOk)
        {
            SpawnMultimeter();
        }
    }

    private void HandleStateChanged(ARSessionStateChangedEventArgs stateEventArguments)
    {
        isSessionQualityOk = stateEventArguments.state == ARSessionState.SessionTracking;
    }

    public GameObject itemPrefab;

    private void SpawnMultimeter()
    {
        HandInfo handInfo = ManomotionManager.Instance.Hand_infos[0].hand_info;
        GestureInfo gestureInfo = handInfo.gesture_info;
        ManoGestureTrigger manoGestureTrigger = gestureInfo.mano_gesture_trigger;

        if(manoGestureTrigger == ManoGestureTrigger.CLICK)
        {
            GameObject newItem = Instantiate(itemPrefab);
            Vector3 positionItem = Camera.main.transform.position + (Camera.main.transform.forward);
            newItem.transform.position = positionItem;
            Handheld.Vibrate();
        }
    }
}
