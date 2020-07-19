using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public WheelCollider WC;
    public float Torque = 200;
    public float MaxSteerAngle = 30;
    public GameObject Wheel;

    // Start is called before the first frame update
    void Start()
    {
        WC = this.GetComponent<WheelCollider>();
    }

    void Go(float acc, float steer) 
    {
        acc = Mathf.Clamp(acc, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * MaxSteerAngle;
        float thrustTorque = acc * Torque;
        WC.motorTorque = thrustTorque;
        WC.steerAngle = steer;

        Quaternion quat;
        Vector3 position;
        WC.GetWorldPose(out position, out quat);
        Wheel.transform.position = position;
        Wheel.transform.rotation = quat;
    }

    // Update is called once per frame
    void Update()
    {
        float acc = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        Go(acc, steer);
    }
}
