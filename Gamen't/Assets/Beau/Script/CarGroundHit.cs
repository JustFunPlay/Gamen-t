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

            a.playRate = 3;
            //print("fuck");
            a.SendEvent("OnSpark");
            Debug.Log(other); 

        }
     
    }
    //public void OnTriggerExit(Collider other)
    //{
    //    a.SendEvent("OnDedSpark");        
    //}

}
