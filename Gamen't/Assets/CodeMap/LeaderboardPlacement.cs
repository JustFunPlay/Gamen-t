using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderboardPlacement : MonoBehaviour
{
    public ScriptableLeaderboardInfo playerLeaderBoardInformation;

    public Text[] lapTime;
    public Text[] playerName;
    public Image[] playerImages;

    public GameObject[] leaderboardCharacters;

    void Start()
    {


    }
    void Update()
    {
        for (int i = 0; i < playerLeaderBoardInformation.leaderboard.Count; i++)
        {
            leaderboardCharacters[i].SetActive(true);
            playerName[i].text = playerLeaderBoardInformation.leaderboard[i].racerName;
            lapTime[i].text = playerLeaderBoardInformation.leaderboard[i].timeInSec.ToString();

        }
    }
    public void OnResetLeaderboard(int scene)
    {
        playerLeaderBoardInformation.leaderboard.Clear();
        SceneManager.LoadScene(scene);
    }
}
