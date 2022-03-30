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
    float restet;
    public float speedRead;
    public bool itStoped;
    public float maxSpeed;
    public float orignalMaxSpeed;
    public float maxSpeedBack;
    public float speedLimiterRange;
    public float brakeOn;
    public Text speedMeterder;
    public bool collided;
    public float handBrake;
    public bool handBrakeOn;
    public Slider speedbalk;
    public bool go;
    bool b;
    public GameObject hudCanvas;
    public bool hasFinished;
    public PlayerInformation playerInformation;
    public Transform checkPoint;
    public Material[] mat;

    public GameObject escMenu;
    private void Start()
    {
        mat = playerInformation.playerSelections[GetComponent<PlayerID>().playerIdNumber].materials;

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = massCenter.localPosition;

    }
    void OnDrive(InputValue value)
    {
        inputGasBrake.y = value.Get<float>();

    }

    void OnMove(InputValue value)
    {
        inputGasBrake.x = value.Get<Vector2>().x;
    }
    void OnReset(InputValue value)
    {
        restet = value.Get<float>();
    }
    void OnESCmenu(InputValue value)
    {
        escMenu.SetActive(true);
        //Time.timeScale = 0.1f;
    }
    void OnHandbrake()
    {
        if (b)
        {
            handBrakeOn = false;
            b = false;
        }
        else
        {
            handBrakeOn = true;
            b = true;
        }
    }
   


    private void FixedUpdate()
    {
        //MAX SNELHEID SYSTEEM DING
        speedRead = rb.velocity.magnitude * 3.6f;
        speedMeterder.text = speedRead.ToString("F0");
        speedbalk.value = speedRead;
        if (go == true)
        {
           
        //Reset de auto terug als die geflipt is
        if (restet == 1)
        {
            transform.position = checkPoint.position;
            transform.rotation = checkPoint.rotation;
            
            restet = 0;
        }



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
                    
                    mat[2].EnableKeyword("_EMISSION");
                    GetComponentInChildren<MeshRenderer>().materials = mat;
                    element.leftWheel.brakeTorque = brakeForce;
                    element.rightWheel.brakeTorque = brakeForce;
                    if (speedRead < 1)
                    {
                        itStoped = true;

                    }
                }
                else
                {
                    mat[2].DisableKeyword("_EMISSION");
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
                    speedbalk.maxValue = maxSpeedBack;
                    if (inputGasBrake.y == 1)
                    {
                        element.leftWheel.brakeTorque = brakeForce;
                        element.rightWheel.brakeTorque = brakeForce;

                        if (speedRead < 1)
                        {
                            if (collided == false)
                            {
                                itStoped = false;
                                maxSpeed = orignalMaxSpeed;
                            }
                            maxSpeed = orignalMaxSpeed;
                            speedbalk.maxValue = orignalMaxSpeed;
                        }
                    }
                }
                    if (handBrakeOn == true)
                    {
                        wheelData[1].rightWheel.brakeTorque = handBrake;
                        wheelData[1].leftWheel.brakeTorque = handBrake;
                        WheelFrictionCurve henk = wheelData[1].leftWheel.sidewaysFriction;
                        WheelFrictionCurve henk1 = wheelData[1].rightWheel.sidewaysFriction;
                        henk.extremumSlip = 0.6f ;
                        henk1.extremumSlip = 0.6f ;
                        wheelData[1].leftWheel.sidewaysFriction = henk;
                        wheelData[1].rightWheel.sidewaysFriction = henk1;

                    }
                    else
                    {
                        WheelFrictionCurve oghenk = wheelData[1].leftWheel.sidewaysFriction;
                        WheelFrictionCurve oghenk1 = wheelData[1].rightWheel.sidewaysFriction;
                        oghenk.extremumSlip = 0.2f;
                        oghenk1.extremumSlip = 0.2f;
                        wheelData[1].leftWheel.sidewaysFriction = oghenk;
                        wheelData[1].rightWheel.sidewaysFriction = oghenk1;
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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            collided = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {

        collided = false;

    }

    public void CarBRR()
    {

        go = true;
        hudCanvas.SetActive(true);
    }
}
