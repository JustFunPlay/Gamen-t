using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "ScriptablePlayerInformation", menuName = "ScriptablePlayerInfo")]
public class PlayerInformation : ScriptableObject
{
    public int totalcars;
    public int maxLaps;

    public List<CheckPointsSingles> totalCheckpoints;
    public List<PlayerSelection> playerSelections;
}

[System.Serializable]
public class PlayerSelection
{
    public string name;
    public GameObject selectedCar;
    public Material selectedCarSkin0;
    public Material selectedCarSkin1;
    public Material selectedCarSkin2;
    public Material selectedCarSkin3;
    public Transform currentCheckpoint;
}
