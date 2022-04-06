using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "ScriptablePlayerInformation", menuName = "ScriptablePlayerInfo")]
public class PlayerInformation : ScriptableObject
{
    public int[] voteNumber;

    public bool raceCupBool;
    public int counter;
    public TrackInfo[] trackInfo;
    //public int nextNumberRace;
    //public int maximumRaces;


    public List<PlayerSelection> playerSelections;
}

[System.Serializable]
public class PlayerSelection
{
    public string name;
    public GameObject selectedCar;
    public Material[] materials = new Material[4];
    public Sprite carImage;

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
