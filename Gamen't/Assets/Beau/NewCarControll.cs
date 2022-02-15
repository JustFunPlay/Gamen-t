using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


[System.Serializable]
public class WheelElements
{

    public WheelCollider leftWheel;
    public WheelCollider rightWheel;

    public bool addWheelTorque;
    public bool shouldSteer;
}

public class NewCarControll : MonoBehaviour
{
    public List<WheelElements> wheelData;
    public float maxTorque;
    public float maxSteerAngle;
    public Vector2 inputGasBrake;
    private Rigidbody rb;
    public Transform massCenter;
    public float brakeForce;
    public float torque;
    public float steer;    
    public float Reverse;
    float restet;
    public float speedRead;
    public bool itStoped;
    public float maxSpeed;
    public float orignalMaxSpeed;
    public float maxSpeedBack;
    public float speedLimiterRange;
    public Material brakeLight;
    public float brakeOn;
    public Text speedMeterder;


    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = massCenter.localPosition;

    }
    void OnDrive(InputValue value)
    {
        inputGasBrake.y = value.Get<float>();

    }
    //void OnBrake(InputValue value)
    //{
    //    inputGasBrake.y = -value.Get<float>();

    //}
    void OnMove(InputValue value)
    {
        inputGasBrake.x = value.Get<Vector2>().x;
    }
    void OnReset(InputValue value)
    {
        restet = value.Get<float>();
    }

    void OnReverse(InputValue value) 
    {
        Reverse = value.Get<float>();
    }




    private void FixedUpdate()
    {
        speedMeterder.text = speedRead.ToString("F0");

        //Reset de auto terug als die geflipt is
        if (restet == 1)
        {

            transform.rotation = new Quaternion();
            restet = 0;
        }

        //MAX SNELHEID SYSTEEM DING
        speedRead = rb.velocity.magnitude * 3.6f;

        float newTorgue = maxTorque;
        if (speedRead > maxSpeed - speedLimiterRange)
        {
            newTorgue = maxTorque * (1 - ((speedRead - (maxSpeed - speedLimiterRange)) / (speedLimiterRange * 1.25f)));
        }
        
        torque = inputGasBrake.y * newTorgue;
        steer = inputGasBrake.x * maxSteerAngle;

        foreach (WheelElements element in wheelData)
        {

            brakeOn = element.leftWheel.brakeTorque;

            if (element.shouldSteer == true)
            {
                element.leftWheel.steerAngle = steer;
                element.rightWheel.steerAngle = steer;
                
            }
            if (element.addWheelTorque == true)
            {
                element.leftWheel.motorTorque = torque;
                element.rightWheel.motorTorque = torque;
                

                if (inputGasBrake.y == -1)
                {

                    element.leftWheel.brakeTorque = brakeForce;
                    element.rightWheel.brakeTorque = brakeForce;
                    if (speedRead < 1)
                    {
                        itStoped = true;
                    }
                }


            }

            if (inputGasBrake.y == 1)
            {
                if (itStoped == false)
                {
                    element.leftWheel.brakeTorque = 0;
                    element.rightWheel.brakeTorque = 0;
                }

            }

            if (itStoped == true)
            {
                element.leftWheel.brakeTorque = 0;
                element.rightWheel.brakeTorque = 0;
                maxSpeed = maxSpeedBack;

                if (inputGasBrake.y == 1)
                {
                    element.leftWheel.brakeTorque = brakeForce;
                    element.rightWheel.brakeTorque = brakeForce;


                }
                if (rb.velocity.z > 0)
                {
                    
                    maxSpeed = orignalMaxSpeed;
                    //itStoped = false;
                }
            }

            DoTyres(element.leftWheel);
            DoTyres(element.rightWheel);
        }

        void DoTyres(WheelCollider collider)
        {

            if (collider.transform.childCount == 0)
            {
                return;
            }

            Transform tyre = collider.transform.GetChild(0);

            Vector3 position;
            Quaternion rotation;

            collider.GetWorldPose(out position, out rotation);

            tyre.transform.position = position;
            tyre.transform.rotation = rotation;
        }

    }
}
