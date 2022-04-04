using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CarGroundHit : MonoBehaviour
{
    public VisualEffect a;
    public bool EnableAirTime;
    public float delayTime;

    public GameObject car;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            if(car.GetComponent<NewCarControll>().speedRead > 30)
            {
                a.Reinit();
                a.playRate = 3;
                a.SendEvent("OnSpark");
                Debug.Log(other + "hitt");
            }
            //update
        }
        EnableAirTime = false;
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Road")
        {
            
            EnableAirTime = true;
        }
        a.SendEvent("OnDedSpark");
    }
    public void FixedUpdate()
    {
        if(EnableAirTime == true)
        {
            delayTime += Time.deltaTime;
        }
        else
        {
            delayTime = 0;
        }

    }

}
