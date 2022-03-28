using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CarGroundHit : MonoBehaviour
{
    public VisualEffect a;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            a.playRate = 2;
            //print("fuck");
            a.SendEvent("OnDED");

        }
        
    }
    
}
