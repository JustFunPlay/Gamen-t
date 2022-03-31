using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CarGroundHit : MonoBehaviour
{
    public VisualEffect a;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Road")
        {
            a.Reinit();
            a.playRate = 3;
            a.SendEvent("OnSpark");
            Debug.Log(other+"hitt"); 

        }
     
    }
    public void OnTriggerExit(Collider other)
    {
        a.SendEvent("OnDedSpark");
    }

}
