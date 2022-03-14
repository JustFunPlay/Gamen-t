using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "ScriptablePlayerInformation", menuName = "ScriptablePlayerInfo")]
public class PlayerInformation : ScriptableObject
{

    public List<CheckPointsSingles> totalCheckpoints;
    public List<PlayerSelection> playerSelections;
}

[System.Serializable]
public class PlayerSelection
{
    public string name;
    public GameObject selectedCar;
    public Material[] materials = new Material[4];

    public PlayerSelection(string name_, GameObject selectedCar_, Material[] materials_)
    {
        this.name = name_;
        this.selectedCar = selectedCar_;
        this.materials = materials_;
    }
    public PlayerSelection(PlayerSelection playerSelection)
    {
        this.name = playerSelection.name;
        this.selectedCar = playerSelection.selectedCar;
        this.materials = playerSelection.materials;
    }
    

    
}
