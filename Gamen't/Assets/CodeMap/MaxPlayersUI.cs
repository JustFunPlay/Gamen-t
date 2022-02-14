using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxPlayersUI : MonoBehaviour
{
    public PlayerInformation playerInfo;

    public GameObject[] listOfPlayerModes;
    public GameObject[] listOfUIModes;
    

    public void OnePlayerMode()
    {
        //playerInfo.maxPlayers = 1;
        listOfPlayerModes[0].SetActive(true);
        
    }
    public void TwoPlayerMode()
    {
        //playerInfo.maxPlayers = 2;
        listOfPlayerModes[0].SetActive(true);

    }

    public void ThreePlayerMode()
    {
        //playerInfo.maxPlayers = 3;
        listOfPlayerModes[0].SetActive(true);
    }

    public void FourPlayerMode()
    {
        //playerInfo.maxPlayers = 4;
        listOfPlayerModes[0].SetActive(true);

    }

    public void DespawnUI()
    {
        listOfUIModes[0].SetActive(false);
        listOfUIModes[1].SetActive(false);
        listOfUIModes[2].SetActive(false);
        listOfUIModes[3].SetActive(false);
    }
}
