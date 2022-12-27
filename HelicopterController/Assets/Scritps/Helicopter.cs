using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [Header("Physics")]
    public Rigidbody _rb;
    public Transform CM;
    public Transform EnginePoint;
    public float RoterPower;
    public float TorquePower;
    public Vector3 inertiaTensor;

    [Header("Inputs")]
    [Range(0,1)]
    public float Throttel;
    [Range(-1, 1)]
    public float InputX;
    [Range(-1, 1)]
    public float InputY;
    [Range(-1, 1)]
    public float InputYaw;

    public Vector3 Velocity;
    public Vector3 LocalVelocity;
    public Vector3 LocalAngularVelocity;

    [Header("instruments")]
    public float Speed;
    public float Altitude;


    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody Settup
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = CM.localPosition;
        _rb.inertiaTensor = inertiaTensor;
    }

    void FixedUpdate()
    {
        //speed in kph
        Speed = Velocity.magnitude * 5.76f;
        //altitude in m
        Altitude = transform.position.y;
        //calculates Velocitiy
        CalculateState();

        //Calcuates Inputs
        InputYaw = Input.GetAxis("Yaw");
        InputY = Input.GetAxis("Vertical");
        InputX = -Input.GetAxis("Horizontal");
        Throttel += Input.mouseScrollDelta.y * 5f / 100f;
        if (Throttel < 0)
        {
            Throttel = 0f;
        }
        if (Throttel > 1)
        {
            Throttel = 1;
        }


        //Physics / Applies Inputs
        _rb.AddForceAtPosition(transform.up * RoterPower * Throttel, EnginePoint.position);
        _rb.AddTorque(transform.forward * TorquePower * InputX);
        _rb.AddTorque(transform.right * TorquePower * InputY);
        _rb.AddTorque(transform.up * TorquePower * InputYaw);
    }

    void CalculateState()
    {
        var invRotation = Quaternion.Inverse(_rb.rotation);
        Velocity = _rb.velocity;
        LocalVelocity = invRotation * Velocity;  //transform world velocity into local space
        LocalAngularVelocity = invRotation * _rb.angularVelocity;  //transform into local space
    }
}
