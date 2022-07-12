using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HandData : MonoBehaviour
{
    public TextMeshPro HandStats;
    HandCollider handCollider;
    // Start is called before the first frame update
    void Start()
    {
        handCollider = FindObjectOfType<HandCollider>();
        HandStats = GameObject.FindObjectOfType<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        HandStats.text = handCollider.currentPosition.ToString();
    }
}
