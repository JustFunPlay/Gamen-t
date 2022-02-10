using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "ScriptablePlayerInformation", menuName = "ScriptablePlayerInfo")]
public class PlayerInformation : ScriptableObject
{
    public int totalPlayers;
    public int maxPlayers;

    public GameObject[] playerTypesOfCars;
    public GameObject[] canvasUI;


}
