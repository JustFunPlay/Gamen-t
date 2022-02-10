using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{

    public PlayerInformation playerInfos;

    public GameObject player;
    public GameObject camera;

    public Vector3[] playerSpawning;
    public int i;
    // i == playerInfos.totalPlayers

    public List<GameObject> listOfPlayers;
    public List<GameObject> listOfCameras;


    public InputActionProperty joinAction { get; set; }
    public bool joiningEnabled { get; }
    public Rect splitScreenArea { get; }
    public bool splitScreen { get; }

    // Start is called before the first frame update
    void Start()
    {
        playerInfos.totalPlayers = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerSpawn()
    {


        if (i < playerInfos.maxPlayers)
        {
            GameObject newplayer = Instantiate(player, playerSpawning[i], Quaternion.identity);
            listOfPlayers.Add(newplayer);

            GameObject newcamera = Instantiate(camera, playerSpawning[i], Quaternion.identity);
            listOfCameras.Add(newcamera);


            i++;
            playerInfos.totalPlayers++;
            UpdateCameras();
        }
        else
        {
            print("too many players");
        }

    }
    public void UpdateCameras()
    {
        switch (playerInfos.totalPlayers) 
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
        }
            
    }
    public void PlayerDespawn()
    {
        if(i > 0)
        {
            i--;
            playerInfos.totalPlayers--;
        }
        Destroy(listOfCameras[i]);
        Destroy(listOfPlayers[i]);
        listOfCameras.RemoveAt(i);
        listOfPlayers.RemoveAt(i);
        UpdateCameras();
        
    }
}
