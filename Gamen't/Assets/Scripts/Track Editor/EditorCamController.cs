using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorCamController : MonoBehaviour
{
    public Vector2 moveVector;
    public Vector2 turnVector;

    public float moveSpeed;
    public float turnSpeed;
    public float heightSpeed;

    void OnMoveCam(InputValue moveValue)
    {
        moveVector = moveValue.Get<Vector2>();
    }
    void OnTurnCam(InputValue turnValue)
    {
        turnVector = turnValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, -turnVector.x * turnSpeed, 0);
        transform.Translate(moveVector.x * moveSpeed, turnVector.y * heightSpeed, moveVector.y * moveSpeed);
    }
}
