using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableCarInformation", menuName = "ScriptableCarInfo")]

public class CarSelect : ScriptableObject
{
    public CarSelection[] Cars;
}

[System.Serializable]
public class CarSelection
{
    //cars
    public GameObject carSelectable;
    public string carNamePlates;

    //carSkins
    public SkinSelection[] skins;
}
[System.Serializable]
public class SkinSelection
{
    public Material skinMaterial0;
    public Material skinMaterial1;
    public Material skinMaterial2;
    public Material skinMaterial3;
    public string skinsNamePlates;
}
