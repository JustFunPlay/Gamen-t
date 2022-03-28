using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerInformation checkpointsHolder;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<NewCarControll>())
        {
            other.GetComponentInParent<NewCarControll>().checkPoint = transform;
            other.GetComponentInParent<PlayerID>().OnCheckpoint();
        }
    }
    public void Start()
    {
        //checkpointsHolder.totalcheckpoints = 0;
        checkpointsHolder.totalcheckpoints++;

    }
}
