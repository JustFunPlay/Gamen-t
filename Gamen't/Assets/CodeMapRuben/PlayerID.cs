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
    public Text checkpointTimeDifText;
    public Animator checkpointAnimation;

    public List<float> checkPointTime;
    public float newCheckPointTime;
    public float oldCheckPointTime;
    public float resetTimer;

    public bool isLinear;
    public bool isCircuit;

    public GameObject insideCar;
    public GameObject[] wheels;
    public RigidbodyConstraints freezePos;



    public void Start()
    {
        CheckPointCounter();
    }

    public void CheckPointCounter()
    {
        checkPointTime.Add(newCheckPointTime);
        
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
    public void OnCheckpoint(int cp)
    {
        float timeDifference = resetTimer - checkPointTime[cp];
        if(isCircuit == true)
        {
            if (timeDifference >= 0)
            {
                checkpointTimeText.text = "+" + timeDifference.ToString("F2");
                checkpointTimeText.color = Color.red;
            }
            if (timeDifference < 0)
            {
                checkpointTimeText.text = timeDifference.ToString("F2");
                checkpointTimeText.color = Color.green;
            }
        }
        checkPointTime[cp] = resetTimer;
        if (isLinear == true)
        {
            checkpointTimeText.text = resetTimer.ToString("F2");
        }

        
        resetTimer = 0;
        checkpointAnimation.SetTrigger("ShowAnimation");

    }
    public void PlayerFinished()
    {
        GetComponent<Rigidbody>().constraints = freezePos;

        insideCar.GetComponent<MeshRenderer>().enabled = false;
        insideCar.GetComponent<MeshCollider>().enabled = false;

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].GetComponent<WheelCollider>().enabled = false;
            wheels[i].GetComponentInChildren<MeshRenderer>().enabled = false;
        }


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
            resetTimer += Time.deltaTime;


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
