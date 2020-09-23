using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public WheelCollider[] WCs;
    public GameObject[] Wheels;
    public float Torque = 200;
    public float MaxSteerAngle = 30;

    // Start is called before the first frame update
    void Start()
    {
        // for (int i = 0; i < 4; i++) 
        // {
        //     WCs[i] = this.GetComponent<WheelCollider>();
        // }
    }

    void Go(float acc, float steer) 
    {
        acc = Mathf.Clamp(acc, -1, 1);
        steer = Mathf.Clamp(steer, -1, 1) * MaxSteerAngle;
        float thrustTorque = acc * Torque;

        for (int i = 0; i < 4; i++) 
        {
            WCs[i].motorTorque = thrustTorque;

            // Front steering
            if (i < 2)
                WCs[i].steerAngle = steer;

            Quaternion quat;
            Vector3 position;
            WCs[i].GetWorldPose(out position, out quat);
            Wheels[i].transform.position = position;
            Wheels[i].transform.rotation = quat;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //float acc = Input.GetAxis("Vertical");
        //float steer = Input.GetAxis("Horizontal");
        //Go(acc, steer);
    }
}
