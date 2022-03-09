using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{

    public PlayerInformation playerInfos;

    public Vector3[] playerSpawning;

    public List<GameObject> listOfPlayers;
    public List<GameObject> listOfCameras;


    public InputActionProperty joinAction { get; set; }
    public bool joiningEnabled { get; }
    public Rect splitScreenArea { get; }
    public bool splitScreen { get; }

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerSpawn()
    {
        for (int i = 0; i < playerInfos.playerSelections.Count; i++)
        {
            if (i < 4)
            {
                GameObject newplayer = Instantiate(playerInfos.playerSelections[i].selectedCar, playerSpawning[i], Quaternion.identity);
                listOfPlayers.Add(newplayer);
                newplayer.GetComponent<PlayerID>().playerIdNumber = i;
                newplayer.GetComponent<PlayerID>().playerName = playerInfos.playerSelections[i].name;

                GameObject newcamera = newplayer.GetComponentInChildren<Camera>().gameObject;
                listOfCameras.Add(newcamera);

                
            }
        }
        UpdateCameras();

    }

    public void UpdateCameras()
    {
        switch (playerInfos.playerSelections.Count) 
        {
            case 1:
                listOfCameras[0].GetComponent<Camera>().rect = new Rect(0,0,1,1);
                break;
            case 2:
                listOfCameras[0].GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
                listOfCameras[1].GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
                break;
            case 3:
                listOfCameras[0].GetComponent<Camera>().rect = new Rect(0.25f, 0.5f, 0.5f, 0.5f);
                listOfCameras[1].GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 0.5f);
                listOfCameras[2].GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                break;
            case 4:
                listOfCameras[0].GetComponent<Camera>().rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                listOfCameras[1].GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                listOfCameras[2].GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 0.5f);
                listOfCameras[3].GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                break;
            default:
                print("fuck");
                break;
        }
            
    }
    // werkt nog niet helemaal
    //public void PlayerDespawn()
    //{

    //    if (playerInfos.playerSelections.Count > 0)
    //    {
    //        Destroy(listOfCameras[playerInfos.totalcars - 1]);
    //        Destroy(listOfPlayers[playerInfos.totalcars - 1]);
    //        listOfCameras.RemoveAt(playerInfos.totalcars - 1);
    //        listOfPlayers.RemoveAt(playerInfos.totalcars - 1);

    //        UpdateCameras();
    //        playerInfos.totalcars--;
    //    }


    //}
}
