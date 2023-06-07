using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionNotifier : MonoBehaviour
{
    public static CollisionNotifier Instance { get; private set; }
    [SerializeField]
    CollisionDetection collisionDetection;
    public Vector3 curPos;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        curPos = this.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        collisionDetection.NotifyCollisionEnter(gameObject, other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        collisionDetection.NotifyCollisionExit(gameObject, other.gameObject);
    }
}
