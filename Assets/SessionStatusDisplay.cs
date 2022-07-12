using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class SessionStatusDisplay : MonoBehaviour
{
    private TextMeshProUGUI sessionStatus;
    // Start is called before the first frame update
    void Start()
    {
        ARSession.stateChanged += HandleStateChanged;
        sessionStatus = this.GetComponent<TextMeshProUGUI>();
    }

    private void HandleStateChanged(ARSessionStateChangedEventArgs statEventArguments)
    {
        switch (statEventArguments.state)
        {
            case ARSessionState.None:
                sessionStatus.text = "Session Status : Unknown";
                break;
            case ARSessionState.Unsupported:
                sessionStatus.text = "Session Status : ARFoundation Not Supported";
                break;
            case ARSessionState.CheckingAvailability:
                sessionStatus.text = "Checking Availability";
                break;
            case ARSessionState.NeedsInstall:
                sessionStatus.text = "Needs Install";
                break;
            case ARSessionState.Installing:
                sessionStatus.text = "Installing";
                break;
            case ARSessionState.Ready:
                sessionStatus.text = "Ready";
                break;
            case ARSessionState.SessionInitializing:
                sessionStatus.text = "POOR SLAM QUALITY";
                break;
            case ARSessionState.SessionTracking:
                sessionStatus.text = "Tracking Quality is Good";
                break;
            default:
                sessionStatus.text = "Session Status : None";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
