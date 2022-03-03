using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerID : MonoBehaviour
{
    public PlayerInformation playerInfo;

    public string playerName;
    public int playerIdNumber;

    public int totalTimesThroughFinish = 1;
    public bool canStart;
    public bool canFinish;


    public float raceTime;
    public Text positionText;


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
                totalTimesThroughFinish++;
                canFinish = false;
                if (totalTimesThroughFinish == playerInfo.maxLaps)
                {
                    print(playerName + " Has Finished");
                    PlayerFinished();
                    
                }

            }
        }
    }
    public void PlayerFinished()
    {

    }

    public void CheckPos(float[] times)
    {
        int numb = 4;
        for (int i = 0; i < times.Length; i++)
        {
            if (times[i] < raceTime && i > 0)
            {
                numb--;
            }
        }
        positionText.text = numb.ToString();
    }

    private void Update()
    {
        raceTime += Time.deltaTime;
    }

}
