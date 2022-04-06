using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{

    public PlayerInformation playerInfos;

    public Transform[] playerSpawning;

    public List<GameObject> listOfPlayers;
    public List<GameObject> listOfCameras;

    public TrackToLoad trackLoader;

    public GameObject escMenuPrefab;
    public GameObject newPlayerAdded;


    public InputActionProperty joinAction { get; set; }
    public bool joiningEnabled { get; }
    public Rect splitScreenArea { get; }
    public bool splitScreen { get; }


    void Start()
    {

        //als je iets hebt ingevuld bij de CUP track list dan gaat de if statement af
        // if (playerInfos.raceCupBool == true)
        //{
        //    if(playerInfos.nextNumberRace == playerInfos.maximumRaces)
        //   {

        //  }
        //  trackLoader.track = playerInfos.trackInfo[playerInfos.nextNumberRace];
        //}
        Instantiate(escMenuPrefab);
    }
   

    public void PlayerSpawn()
    {
        for (int i = 0; i < playerInfos.playerSelections.Count; i++)
        {
            if (i < 4)
            {
                GameObject newplayer = Instantiate(playerInfos.playerSelections[i].selectedCar, playerSpawning[i].position, playerSpawning[i].rotation);
                listOfPlayers.Add(newplayer);
                newPlayerAdded = newplayer;
                newplayer.transform.GetChild(0).GetComponent<PlayerID>().playerIdNumber = i;
                newplayer.transform.GetChild(0).GetComponent<PlayerID>().playerName = playerInfos.playerSelections[i].name;

                newplayer.transform.GetChild(0).GetComponent<NewCarControll>().escMenuAUTO = GameObject.Find("BETTER ESC(Clone)");
                newplayer.transform.GetChild(0).GetComponent<NewCarControll>().mainMenuAUTO = GameObject.Find("ESC");

                if (playerInfos.raceCupBool == true)
                {
                    //newplayer.transform.GetChild(0).GetComponent<PlayerID>().maxLaps = playerInfos.trackInfo[playerInfos.nextNumberRace].numberOfLaps;
                }
                else
                {
                    newplayer.transform.GetChild(0).GetComponent<PlayerID>().maxLaps = trackLoader.track.numberOfLaps;
                }
                
                
                List<Material> newMats = new List<Material>();
                for (int a = 0; a < playerInfos.playerSelections[i].materials.Length; a++)
                {

                    newMats.Add(new Material(playerInfos.playerSelections[i].materials[a]));
                }
                newplayer.transform.GetChild(0).transform.GetChild(1).GetComponent<MeshRenderer>().materials = newMats.ToArray();
                GameObject newcamera = newplayer.GetComponentInChildren<Camera>().gameObject;
                listOfCameras.Add(newcamera);

                
            }
        }
        newPlayerAdded.transform.GetChild(0).GetComponent<NewCarControll>().escMenuAUTO.SetActive(false);
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
