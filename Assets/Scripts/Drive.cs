using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public WheelCollider WC;
    public float Torque = 200;

    // Start is called before the first frame update
    void Start()
    {
        WC = this.GetComponent<WheelCollider>();
    }

    void Go(float acc) 
    {
        acc = Mathf.Clamp(acc, -1, 1);
        float thrustTorque = acc * Torque;
        WC.motorTorque = thrustTorque;

        Quaternion quat;
        Vector3 position;
        WC.GetWorldPose(out position, out quat);
        this.transform.position = position;
        this.transform.rotation = quat;
    }

    // Update is called once per frame
    void Update()
    {
        float acc = Input.GetAxis("Vertical");
        Go(acc);
    }
}
