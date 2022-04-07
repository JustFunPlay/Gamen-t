using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToTrack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponentInParent<NewCarControll>())
        {
            collision.collider.GetComponentInParent<NewCarControll>().ResetToCheckpoint();
        }
    }
}
