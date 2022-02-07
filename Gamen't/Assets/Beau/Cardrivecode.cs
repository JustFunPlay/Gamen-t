using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cardrivecode : MonoBehaviour
{
    public WheelCollider[] wheels;
    public GameObject[] wheelsmesh;
    public float motorPower;
    public float steerPower;
    public float speed;
    public Vector2 brrr;
    

    void OnDrive(InputValue value)
    {
        brrr.y = value.Get<float>();
    }
    void OnBrake(InputValue value)
    {
        brrr.y = -value.Get<float>();
    }

    void OnMove(InputValue value)
    {
        brrr.x = value.Get<Vector2>().x;
    }


    private void FixedUpdate()
    {


        foreach (var wheel in wheels)
        {
            if (brrr.y == -1)
            {
                wheel.brakeTorque = 1000;
            }



            wheel.motorTorque = brrr.y * motorPower;
            
            speed = wheel.motorTorque;


        }


        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].GetWorldPose(out var pos, out var rot);
            wheelsmesh[i].transform.position = pos;
            wheelsmesh[i].transform.rotation = rot;
            if (i < 2)
            {
                wheels[i].steerAngle = brrr.x * steerPower;

            }



        }

    }
}
