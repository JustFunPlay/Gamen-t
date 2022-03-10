using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerID : MonoBehaviour
{
    public PlayerInformation playerInfo;

    public string playerName;
    public int playerIdNumber;

    public int labCount;
    public bool canStart;
    public bool canFinish;


    public float raceTime;
    public Text positionText;

    public GameObject finishScreen;
    public Text endPositionText;
    public int endPosition;

    public int maxLaps;

    public ScriptableLeaderboardInfo leaderboardInfo;

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint begin")
        {
            if (canStart == true)
            {
                canFinish = true;
            }  
        }
        if (other.gameObject.tag == "CheckPoint meanwhile")
        {
            canStart = false;
        }
        if (other.gameObject.tag == "CheckPoint end")
        {
            canStart = true;
            if(canFinish == true)
            {
                labCount++;
                canFinish = false;
                if (labCount > maxLaps)
                {
                    print(playerName + " Has Finished");
                    if (GetComponent<NewCarControll>().go == true)
                    {
                        PlayerFinished();
                    }
                    
                }

            }
            if (labCount == 0)
            {
                labCount = 1;
            }
        }
    }
    public void PlayerFinished()
    {
        GetComponent<NewCarControll>().go = false;
        GetComponent<NewCarControll>().hasFinished = true;
        finishScreen.SetActive(true);
        endPositionText.text = endPosition.ToString();
        leaderboardInfo.leaderboard.Add(new Leaderboard(playerName, raceTime));

    }

    public void CheckPos(List<PosCP> positions)
    {
        int position = positions.Count;
        for (int i = 0; i < positions.Count; i++)
        {
            if (positions[i].lap < labCount)
            {
                position--;
            }
        }
        positionText.text = position.ToString();
        endPosition = position;
    }

    private void Update()
    {
        if(GetComponent<NewCarControll>() && GetComponent<NewCarControll>().go == true)
        {
            raceTime += Time.deltaTime;
        }
        
    }

}
