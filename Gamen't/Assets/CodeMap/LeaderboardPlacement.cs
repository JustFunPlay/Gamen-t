using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPlacement : MonoBehaviour
{
    public PlayerInformation playerInformation;

    public Text[] lapTime;
    public Text[] playerName;
    public Image[] playerImages;

    public GameObject[] leaderboardCharacters;

    void Start()
    {

        for (int i = 0; i < playerInformation.playerSelections.Count; i++)
        {
            playerName[i].text = playerInformation.playerSelections[i].name[i].ToString();
            leaderboardCharacters[i].SetActive(true);
        }
    }
}
