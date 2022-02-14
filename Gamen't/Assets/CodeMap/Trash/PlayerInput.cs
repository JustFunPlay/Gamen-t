using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public PlayerInformation playerInfo;

    public float playerIDnumber;

    public Rigidbody rb;
    public float speed = 20;
    public Vector2 moveValue;
    public Vector2 movementVector;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 

     void FixedUpdate()
     {
        Vector3 movement = new Vector3(moveValue.x, 0, moveValue.y);
        rb.AddRelativeForce(movement * speed);
     }
    public void OnResetCarPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Gimme git");
            //GetComponent<Transform>().rotation.eulerAngles = rotationValue(9, 9, 9); 
            transform.rotation = new Quaternion();
        }
        
    }
    public void OnMoving(InputAction.CallbackContext context)
    {
        movementVector = context.action.ReadValue<Vector2>();

        moveValue.x = movementVector.x;
        moveValue.y = movementVector.y;
    }
}

