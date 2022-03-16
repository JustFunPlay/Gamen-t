using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform player;

    public float speedNumber;
    public Vector3 offset;

    //public Vector3 desiredPosition;
    

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothToPosition = Vector3.Lerp(transform.position, desiredPosition, speedNumber * Time.deltaTime);
        transform.position = smoothToPosition;
    }
}
