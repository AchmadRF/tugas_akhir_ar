using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formula : MonoBehaviour
{
    public static Formula instance;
    [SerializeField]
    private float voltage;
    [SerializeField]
    private float current;
    [SerializeField]
    private float resistance;
    // Start is called before the first frame update
    public float Voltage
    {
        get { return voltage; }
        set { voltage = value; }
    }
    public float Current
    {
        get { return current; }
        set { current = value; }
    }
    public float Resistance
    {
        get { return resistance; }
        set { resistance = value; }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float CalculateVoltage(float current, float resistance)
    {
        return current * resistance;
    }
    public float CalculateAmperage(float voltage, float resistance)
    {
        return voltage / resistance;
    }
    public float CalculateResistance(float current, float voltage)
    {
        return voltage / current;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
