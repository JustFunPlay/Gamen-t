using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public float restet;
    public float speedRead;
    public bool isSpeed;
    public float rPM;
    public bool itGoesBack;
    public float maxSpeed;
    public float speedLimiterRange;
    public Material brakeLight;
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



    public void OnReset(InputValue value)
    {
        restet = value.Get<float>();
    }


    private void FixedUpdate()
    {
        if (restet == 1)
        {
            Debug.Log("Gimme git");
            transform.rotation = new Quaternion();
            restet = 0;
        }

        speedRead = rb.velocity.magnitude * 3.6f;
        if (speedRead > 200)
        {
            isSpeed = true;
        }
        float newTorgue = maxTorque;
        if (speedRead > maxSpeed - speedLimiterRange)
        {
            newTorgue = maxTorque * (1 - ((speedRead - (maxSpeed - speedLimiterRange)) / (speedLimiterRange * 1.25f)));
        }

        torque = brrr.y * newTorgue;
        steer = brrr.x * maxSteerAngle;

        foreach (WheelElements element in wheelData)
        {
            if (element.shouldSteer == true)
            {
                element.leftWheel.steerAngle = steer;
                element.rightWheel.steerAngle = steer;
            }
            if (element.addWheelTorque == true)
            {
                rPM = element.leftWheel.rpm;


                element.leftWheel.motorTorque = torque;
                element.rightWheel.motorTorque = torque;



            }

            if (brrr.y == -1)
            {
                brakeLight.EnableKeyword("_EMISSION");
                element.leftWheel.brakeTorque = brakeForce;
                element.rightWheel.brakeTorque = brakeForce;
            }
            else
            {
                brakeLight.DisableKeyword("_EMISSION");
                element.leftWheel.brakeTorque = 0;
                element.rightWheel.brakeTorque = 0;
            }

            //if (rb.velocity.z <= 0)
            //{
            //    element.leftWheel.brakeTorque = 0;
            //    element.rightWheel.brakeTorque = 0;
            //    if(brrr.y == -1)
            //    {
            //        itGoesBack = true;
            //    }
            //}


            DoTyres(element.leftWheel);
            DoTyres(element.rightWheel);
        }
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
