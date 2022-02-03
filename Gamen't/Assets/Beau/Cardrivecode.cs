using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardrivecode : MonoBehaviour
{
    public WheelCollider[] wheels;
    public GameObject[] wheelsmesh;
    public float motorPower = 100;
    public float steerPower = 100;


    private void FixedUpdate()
    {
        

        foreach (var wheel in wheels)
        {
            wheel.motorTorque = Input.GetAxis("Vertical") * motorPower;
            
      
        }


        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].GetWorldPose(out var pos, out var rot);
            wheelsmesh[i].transform.position = pos;
            wheelsmesh[i].transform.rotation = rot;
            if (i < 2)
            {
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steerPower;
                
            }



        }
    }


}
