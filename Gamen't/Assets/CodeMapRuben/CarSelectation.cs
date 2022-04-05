using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class CarSelectation : MonoBehaviour
{
    public CarSelect carInventory;
    public int carNumber;
    public int skinNumber;
    public Transform carPos;

    public GameObject carTesting;
    public GameObject goingInCar;

    public GameObject replaceSkinText; 

    public PlayerInformation playerInformation;

    public int id;

    public Text playerName;

    private void Start()
    {
        OnCarSpawn();
        OnSkinSpawn();

        carInventory.Cars[carNumber].skins[skinNumber].materials[2].DisableKeyword("_EMISSION");
    }
    public void OnRightClickCarButton()
    {
        if (carNumber < carInventory.Cars.Length - 1)
        {
            carNumber++;
        }
        else
        {
            carNumber = 0;
        }
        OnCarSpawn();
    }
    public void OnLeftClickCarButton()
    {
        if(carNumber > 0)
        {
            carNumber--;
        }
        else
        {
            carNumber = carInventory.Cars.Length -1;
        }
        OnCarSpawn();
    }
    void OnCarSpawn()
    {
        if (carPos.childCount > 0)
        {
            Destroy(carPos.GetChild(0).gameObject);
        }
        carTesting = Instantiate(carInventory.Cars[carNumber].carSelectable, carPos.position, carPos.rotation, carPos);
        skinNumber = 0;
        OnSkinSpawn();
        
    }
    
    public void OnRightClickSkinButton()
    {
        if(skinNumber < carInventory.Cars[carNumber].skins.Length -1)
        {
            skinNumber++;
        }
        else
        {
            skinNumber = 0;
        }
        OnSkinSpawn();
    }
    public void OnLeftClickSkinButton()
    {
        if(skinNumber > 0)
        {
            skinNumber--;
        }
        else
        {
            skinNumber = carInventory.Cars[carNumber].skins.Length -1;
        }
        OnSkinSpawn();
    }
    void OnSkinSpawn()
    {
        replaceSkinText.GetComponent<Text>().text = carInventory.Cars[carNumber].skins[skinNumber].skinsNamePlates;
        goingInCar = carTesting.transform.GetChild(0).transform.GetChild(1).gameObject;
        goingInCar.GetComponent<MeshRenderer>().materials = carInventory.Cars[carNumber].skins[skinNumber].materials;


        //goingInCar.GetComponent<MeshRenderer>().materials[0] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial0;
        //goingInCar.GetComponent<MeshRenderer>().materials[1] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial1;
        //goingInCar.GetComponent<MeshRenderer>().materials[2] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial2;
        //goingInCar.GetComponent<MeshRenderer>().materials[3] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial3;


        Selection();
    }

    void Selection()
    {
        playerInformation.playerSelections[id].name = playerName;
        //int id = GetComponentInParent<PlayerID>().playerIdNumber;
        playerInformation.playerSelections[id].selectedCar = carInventory.Cars[carNumber].carSelectable;
        playerInformation.playerSelections[id].materials = carInventory.Cars[carNumber].skins[skinNumber].materials;
        playerInformation.playerSelections[id].carImage = carInventory.Cars[carNumber].carImage;

        print("How many fucks to give: " + id.ToString());
    }
}
