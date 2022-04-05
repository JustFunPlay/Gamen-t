using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorCamController : MonoBehaviour
{
    public Vector2 moveVector;
    public Vector2 turnVector;

    public float turnSpeed;

    public CreateGrid grid;
    public NodeInfo currentNode;

    public bool worky = true;
    void OnMoveCam(InputValue moveValue)
    {
        moveVector = moveValue.Get<Vector2>();
        MoveInGrid();
    }
    void OnTurnCam(InputValue turnValue)
    {
        turnVector = turnValue.Get<Vector2>();
        MoveInGrid();
    }
    private void Start()
    {
        NodeInfo[] nodeInfos = FindObjectsOfType<NodeInfo>();
        foreach (NodeInfo node in nodeInfos)
        {
            if (node.gridLocation.x == (int)(grid.gridsize.x * 0.5f) && node.gridLocation.y == 0 && node.gridLocation.z == (int)(grid.gridsize.z * 0.5f))
            {
                currentNode = node;
                break;
            }
        }
        transform.position = currentNode.transform.position;
    }

    private void FixedUpdate()
    {
        if (worky)
        {
            transform.Rotate(0, -turnVector.x * turnSpeed, 0);
        }
        //transform.Translate(moveVector.x * moveSpeed, turnVector.y * heightSpeed, moveVector.y * moveSpeed);
    }

    void MoveInGrid()
    {
        if (worky)
        {
            NodeInfo[] nodeInfos = FindObjectsOfType<NodeInfo>();
            foreach (NodeInfo node in nodeInfos)
            {
                if (node.gridLocation.x == currentNode.gridLocation.x + moveVector.x && node.gridLocation.y == currentNode.gridLocation.y + turnVector.y && node.gridLocation.z == currentNode.gridLocation.z + moveVector.y)
                {
                    currentNode = node;
                    break;
                }
            }
            transform.position = currentNode.transform.position;
        }
    }
    public void ToggleEditorControlls()
    {
        if (worky)
        {
            worky = false;
        }
        else
        {
            worky = true;
        }
    }
}
