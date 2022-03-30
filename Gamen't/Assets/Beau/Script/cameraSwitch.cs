using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class cameraSwitch : MonoBehaviour
{
    public GameObject old;
    public GameObject neew;

    public float swit;
    public Vector3 amountSwitch;
    public void OnSwitch()
    {
        swit += 1;
        
    }

    public void Update()
    {
        if (swit == 1)
        {
            //old.SetActive(false);
            //neew.SetActive(true);
            old.GetComponent<Transform>().rotation
        }

        if (swit == 2)
        {
            old.SetActive(true);
            neew.SetActive(false);
            swit = 0;
        }
    }
}
