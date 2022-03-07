using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class CarSelectation : MonoBehaviour
{
    //public SkinSelection skinsInventory;
    public CarSelect carInventory;
    public int carNumber;
    public int skinNumber;
    public Transform carPos;

    public GameObject carTesting;
    public GameObject inCarTesting;

    public Material materialTest1;

    private void Start()
    {
        OnCarSpawn();
        OnSkinSpawn();
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

        //carTesting = carInventory.Cars[carNumber].carSelectable;
    }
    // below this werkt het nog niet helemaal
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
        
        inCarTesting = carTesting.transform.GetChild(4).gameObject;


        Material[] material = inCarTesting.GetComponent<MeshRenderer>().materials;

        material[0] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial0;
        material[1] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial1;
        material[2] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial2;
        material[3] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial3;

        inCarTesting.GetComponent<MeshRenderer>().materials = material;


        //inCarTesting.GetComponent<MeshRenderer>().materials[1] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial0;
        //inCarTesting.GetComponent<MeshRenderer>().materials[1] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial1;
        //inCarTesting.GetComponent<MeshRenderer>().materials[2] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial2;
        //inCarTesting.GetComponent<MeshRenderer>().materials[3] = carInventory.Cars[carNumber].skins[skinNumber].skinMaterial3;



    }
}
