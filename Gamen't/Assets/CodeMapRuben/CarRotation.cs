using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRotation : MonoBehaviour
{
    public float rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(0.0f, rotationSpeed * Time.fixedDeltaTime, 0f, Space.World);
    }
}
