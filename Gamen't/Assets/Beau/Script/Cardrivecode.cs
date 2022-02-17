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
    public float brakePower;
    public float handBrake;

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

    void OnHandbrake(InputValue value)
    {
        handBrake = value.Get<float>();
    }
    public void OnResetCarPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Gimme git");

            transform.rotation = new Quaternion();
        }

    }

    private void FixedUpdate()
    {


        foreach (var wheel in wheels)
        {
            if(brrr.y >= 0)
            {
                wheels[2].motorTorque = brrr.y * motorPower;
                wheels[3].motorTorque = brrr.y * motorPower;


            }
            if (handBrake == 1)
            {
                wheels[2].brakeTorque = handBrake * brakePower;
                wheels[3].brakeTorque = handBrake * brakePower;
                //handBrake = 0;
            }
            else
            {
                wheels[2].brakeTorque = 0;
                wheels[3].brakeTorque = 0;
            }

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
