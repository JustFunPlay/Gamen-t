using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.VFX;


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
    public float handBrake;
    public bool handBrakeOn;
    public Slider speedbalk;
    public bool go;
    bool b;
    public GameObject hudCanvas;
    public bool hasFinished;
    public PlayerInformation playerInformation;

    public Transform checkPoint;
    Vector3 addPosition;
    int randomResetSpawner;

    public GameObject escMenuAUTO;
    public GameObject mainMenuAUTO;
    public static bool escMenuBool;

    public Material[] mat;

    public TrailRenderer slipperyTrail0;
    public TrailRenderer slipperyTrail1;

    public int NumberBack;

    public VisualEffect smokeParticleL;
    public VisualEffect smokeParticleR;

    private void Start()
    {
        mat = playerInformation.playerSelections[GetComponent<PlayerID>().playerIdNumber].materials;
        mat[NumberBack].DisableKeyword("_EMISSION");
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = massCenter.localPosition;

        addPosition = new Vector3(0, -2, 0);

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

        if (restet == 1)
        {
            if(go == true)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                rb.constraints = RigidbodyConstraints.None;

                addPosition.x = Random.Range(-4.25f, 4.25f);
                transform.position = checkPoint.position;
                transform.localPosition += addPosition;

                transform.rotation = checkPoint.rotation;

                restet = 0;
            }

        }
    }
    // 1. je krijgt access als je op ESC drukt en een conditie op true of false staat. 2. 
    void OnESCmenu(InputValue value)
    {
        if (escMenuBool == false)
        {
            
           escMenuBool = true;
            escMenuAUTO.SetActive(true);
            
            Time.timeScale = 0.0000001f;
            
            
        }
        else
        {
            if(escMenuBool == true)
            {
               escMenuBool = false;
                escMenuAUTO.SetActive(false);
                Time.timeScale = 1f;
            }

        }
    }
    void OnHandbrake()
    {
        if (b)
        {
            handBrakeOn = false;
            b = false;

            slipperyTrail0.emitting = false;
            slipperyTrail1.emitting = false;

            smokeParticleL.SendEvent("OnSmokeDed");
            smokeParticleR.SendEvent("OnSmokeDed");
        }
        else
        {
            handBrakeOn = true;
            b = true;

            slipperyTrail0.emitting = true;
            slipperyTrail1.emitting = true;

            smokeParticleL.Reinit();
            smokeParticleR.Reinit();

            smokeParticleL.SendEvent("OnSmoke");
            smokeParticleR.SendEvent("OnSmoke");
        }
    }
    void OnBrake(InputValue value)
    {
        if(value.Get<float>() == 1)
        {
            slipperyTrail0.emitting = true;
            slipperyTrail1.emitting = true;

            smokeParticleL.Reinit();
            smokeParticleR.Reinit();

            smokeParticleL.SendEvent("OnSmoke");
            smokeParticleR.SendEvent("OnSmoke");
        }
        else
        {
            slipperyTrail0.emitting = false;
            slipperyTrail1.emitting = false;

            smokeParticleL.SendEvent("OnSmokeDed");
            smokeParticleR.SendEvent("OnSmokeDed");
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
                    
                    mat[NumberBack].EnableKeyword("_EMISSION");
                    GetComponentInChildren<MeshRenderer>().materials = mat;
                    element.leftWheel.brakeTorque = brakeForce;
                    element.rightWheel.brakeTorque = brakeForce;
                   
                    if (speedRead < 1)
                    {
                       itStoped = true;
                       slipperyTrail0.emitting = false;
                       slipperyTrail1.emitting = false;
                    }
                    

                }
                else
                {
                    mat[NumberBack].DisableKeyword("_EMISSION");
                }


            }

            if (inputGasBrake.y == 1)
            {
                    speedbalk.maxValue = orignalMaxSpeed;
                    maxSpeed = orignalMaxSpeed;
                    itStoped = false;
                    element.leftWheel.brakeTorque = 0;
                    element.rightWheel.brakeTorque = 0;
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

    public void CarBRR()
    {

        go = true;
        hudCanvas.SetActive(true);
    }
}
