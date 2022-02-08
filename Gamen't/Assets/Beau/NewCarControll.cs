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
    public float maxSteerAngle = 30;
    public Vector2 brrr;
    public float handBrake;
    private Rigidbody rb;
    public Transform massCenter;
    public float decelerationforce;
    public float speed;
    public float steer;
    public bool stoppedCar;

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

    void OnHandbrake(InputValue value)
    {
        handBrake = value.Get<float>();
    }

    private void FixedUpdate()
    {
        speed = brrr.y * maxTorque;
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
                element.leftWheel.motorTorque = speed;
                element.rightWheel.motorTorque = speed;
            }
            if (brrr.y == -1)
            {
                element.leftWheel.brakeTorque = decelerationforce;
                element.rightWheel.brakeTorque = decelerationforce;
                stoppedCar = true;
            }
            //if(stoppedCar == true)
            //{
            //    element.leftWheel.brakeTorque = 0;
            //    element.rightWheel.brakeTorque = 0;
            //    stoppedCar = false;
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
