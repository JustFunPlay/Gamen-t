using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //carPhoto
    public Image carImage;
}
[System.Serializable]
public class SkinSelection
{
    public Material[] materials = new Material[4];
    public string skinsNamePlates;
}
