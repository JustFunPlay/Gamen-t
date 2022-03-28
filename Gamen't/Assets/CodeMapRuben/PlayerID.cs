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

    public Text lapText;
    public Text timeText;

    public Text checkpointTimeText;
    public Animator checkpointAnimation;

    public List<int> checkpointTotal;
    public float resettedTimer;
    public float newCheckPointTime;
    public float oldCheckPointTime;





    public void CheckPointCounter()
    {
        for (int i = 0; i < playerInfo.totalcheckpoints; i++)
        {
            int yes = 0;
            
            checkpointTotal.Add(yes);
        }
    }
    IEnumerator ie()
    {
       yield return new WaitForSeconds(1);
        CheckPointCounter();
    }
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
                lapText.text = labCount.ToString();
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
                lapText.text = labCount.ToString();
            }
        }
    }
    [System.Serializable]
    public class ThisCheckPoint
    {
        float timeNumber;

        public ThisCheckPoint(float timeNumber_)
        {
            this.timeNumber = timeNumber_;
        }
        public ThisCheckPoint(ThisCheckPoint thisCheckPoint)
        {
            this.timeNumber = thisCheckPoint.timeNumber;

        }
    }
    public void OnCheckpoint()
    {
        resettedTimer = raceTime;
        newCheckPointTime = resettedTimer;
        resettedTimer = 0;



        checkpointTimeText.text = timeText.text;
        checkpointAnimation.SetTrigger("ShowAnimation");

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


            if (raceTime < 10)
            {
                timeText.text = "0:0" + raceTime.ToString("F2");
            }
            else if (raceTime < 60)
            {
                timeText.text = "0:" + raceTime.ToString("F2");
            }
            else
            {
                int m = 0;
                float s = raceTime;
                while (s > 60)
                {
                    s -= 60;
                    m++;
                }
                if (s < 10)
                {
                    timeText.text = m.ToString() + ":0" + s.ToString("F2");
                }
                else
                {
                    timeText.text = m.ToString() + ":" + s.ToString("F2");
                }

            }

        }


    }

}
