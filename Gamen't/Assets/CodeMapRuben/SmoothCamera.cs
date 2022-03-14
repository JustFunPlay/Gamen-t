using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform player;

    public float speedNumber;
    public Vector3 offset;
    

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothToPosition = Vector3.Lerp(transform.position, desiredPosition, speedNumber * Time.deltaTime);
        transform.position = smoothToPosition;
    }
}
