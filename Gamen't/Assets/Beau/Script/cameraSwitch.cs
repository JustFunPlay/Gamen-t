using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class cameraSwitch : MonoBehaviour
{
    public Transform cameraPos;
    public Vector3 positionBackCamera;
    public Vector3 positionForwardCamera;

    float switchFloatAUTO;
    void OnSwitch(InputValue value)
    {
        switchFloatAUTO = value.Get<float>();
        print(switchFloatAUTO);
        AfterSwitch();
    }
    public void AfterSwitch()
    {

        if (switchFloatAUTO == 1)
        {
            cameraPos.localPosition = positionBackCamera;
            cameraPos.Rotate(0, -180, 0);
        }
        else
        {
            cameraPos.localPosition = positionForwardCamera;
            cameraPos.Rotate(0, 180, 0);
        }
    }
}
