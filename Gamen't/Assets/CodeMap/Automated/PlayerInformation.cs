using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "ScriptablePlayerInformation", menuName = "ScriptablePlayerInfo")]
public class PlayerInformation : ScriptableObject
{
    public int totalcars;

    public List<CheckPointsSingles> totalCheckpoints;
    public List<PlayerSelection> playerSelections;
}

[System.Serializable]
public class PlayerSelection
{
    public string name;
    public GameObject selectedCar;
    public Material selectedCarSkin;
    public Transform currentCheckpoint;
}
