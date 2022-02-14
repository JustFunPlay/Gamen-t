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
    public Vector2 brrr;
    public float handBrake;
    private Rigidbody rb;
    public Transform massCenter;
    public float brakeForce;
    public float torque;
    public float steer;
    float restet;
    public float speedRead;
    public bool itStoped;
    public float maxSpeed;
    public float orignalMaxSpeed;
    public float maxSpeedBack;
    public float speedLimiterRange;
    public Material brakeLight;
    public float brakeOn;
    


    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = massCenter.localPosition;

    }
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
    void OnReset(InputValue value)
    {
        restet = value.Get<float>();
    }


    private void FixedUpdate()
    {


        //Reset de auto terug als die geflipt is
        if (restet == 1)
        {
            Debug.Log("Gimme git");
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
        
        torque = brrr.y * newTorgue;
        steer = brrr.x * maxSteerAngle;

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
            }

            if (brrr.y == -1)
            {
                element.leftWheel.brakeTorque = brakeForce;
                element.rightWheel.brakeTorque = brakeForce;
                if (rb.velocity.z < 0)
                {
                    itStoped = true;
                }
            }


            if (itStoped == true)
            {
                element.leftWheel.brakeTorque = 0;
                element.rightWheel.brakeTorque = 0;
                maxSpeed = maxSpeedBack;

                if (brrr.y == 1)
                {
                    element.leftWheel.brakeTorque = brakeForce;
                    element.rightWheel.brakeTorque = brakeForce;

                    if (rb.velocity.z > 0)
                    {
                        element.leftWheel.brakeTorque = 0;
                        element.rightWheel.brakeTorque = 0;
                        if (brakeOn == 0)
                        {
                            itStoped = false;
                        }
                    }

                }
            }
            else
            {
                maxSpeed = orignalMaxSpeed;
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
