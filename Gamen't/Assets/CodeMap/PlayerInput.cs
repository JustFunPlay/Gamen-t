using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 50;
    public Vector2 moveValue;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnMove(InputValue movementValue)
    {
       Vector2 movementVector = movementValue.Get<Vector2>();

        moveValue.x = movementVector.x;
        moveValue.y = movementVector.y;
    }

     void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0, moveValue.y);
        rb.AddRelativeForce(movement * speed);
    }
}

