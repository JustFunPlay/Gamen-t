using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MaxPlayersUI : MonoBehaviour
{
    public PlayerInformation playerInfo;


    public GameObject[] listOfPlayerModes;
    public GameObject[] listOfEvents;

    private void Start()
    {
        
    }
    public void ToScene()
    {
        SceneManager.LoadScene(4);
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
