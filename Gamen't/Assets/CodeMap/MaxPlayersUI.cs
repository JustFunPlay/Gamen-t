using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxPlayersUI : MonoBehaviour
{
    public PlayerInformation playerInfo;


    public GameObject[] listOfPlayerModes;
    public GameObject[] listOfEvents;

    private void Start()
    {
        if (playerInfo.playerSelections.Count == 1)
        {
            listOfEvents[0].SetActive(true);
        }
        if (playerInfo.playerSelections.Count == 2)
        {
            listOfEvents[0].SetActive(true);
            listOfEvents[1].SetActive(true);
        }
        if (playerInfo.playerSelections.Count == 3)
        {
            listOfEvents[0].SetActive(true);
            listOfEvents[1].SetActive(true);
            listOfEvents[2].SetActive(true);
        }
        if (playerInfo.playerSelections.Count == 4)
        {
            listOfEvents[0].SetActive(true);
            listOfEvents[1].SetActive(true);
            listOfEvents[2].SetActive(true);
            listOfEvents[3].SetActive(true);
        }
    }


    
    public void OnePlayerMode()
    {

        
    }
    public void TwoPlayerMode()
    {
        

    }

    public void ThreePlayerMode()
    {


    }

    public void FourPlayerMode()
    {


    }

    public void DespawnUI()
    {
        listOfEvents[0].SetActive(false);
        listOfEvents[1].SetActive(false);
        listOfEvents[2].SetActive(false);
        listOfEvents[3].SetActive(false);
    }
}
