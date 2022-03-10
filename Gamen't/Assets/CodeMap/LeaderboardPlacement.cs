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
            if (playerLeaderBoardInformation.leaderboard[i].timeInSec < 10)
            {
                lapTime[i].text = "0:0" + playerLeaderBoardInformation.leaderboard[i].timeInSec.ToString("F2");
            }
            else if (playerLeaderBoardInformation.leaderboard[i].timeInSec < 60)
            {
                lapTime[i].text = "0:" + playerLeaderBoardInformation.leaderboard[i].timeInSec.ToString("F2");
            }
            else
            {
                int m = 0;
                float s = playerLeaderBoardInformation.leaderboard[i].timeInSec;
                while (s > 60)
                {
                    s -= 60;
                    m++;
                }
                if(s < 10)
                {
                    lapTime[i].text = m.ToString() + ":0" + s.ToString("F2");
                }
                else
                {
                    lapTime[i].text = m.ToString() + ":" + s.ToString("F2");
                }

            }
        }

    }
    public void OnResetLeaderboard(int scene)
    {
        playerLeaderBoardInformation.leaderboard.Clear();
        SceneManager.LoadScene(scene);
    }
}
