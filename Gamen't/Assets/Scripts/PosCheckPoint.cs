using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCheckPoint : MonoBehaviour
{
    public float[] times = new float[4];
    private void Start()
    {
        for (int i = 0; i < times.Length; i++)
        {
            times[i] = -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<PlayerID>())
        {
            times[other.GetComponentInParent<PlayerID>().playerIdNumber] = other.GetComponentInParent<PlayerID>().raceTime;
            other.GetComponentInParent<PlayerID>().CheckPos(times);
        }
    }
}
