using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class cameraSwitch : MonoBehaviour
{
    public Transform cameraPos;
    public Vector3 positionBackCamera;
    public Vector3 positionForwardCamera;

    public Vector3 positionReset;

    float switchFloat;
    void OnSwitch(InputValue value)
    {
        switchFloat = value.Get<float>();
        AfterSwitch();
    }
    public void AfterSwitch()
    {
        //cameraPos.position = positionReset;

        if (switchFloat == 1)
        {
            cameraPos.localPosition += positionBackCamera;

            cameraPos.Rotate(0, -180, 0);
        }
        else
        {
            if (switchFloat == 0)
            {
                cameraPos.localPosition += positionForwardCamera;

                cameraPos.Rotate(0, 180, 0);
            }
        }
    }

    public void Update()
    {

    }
}
