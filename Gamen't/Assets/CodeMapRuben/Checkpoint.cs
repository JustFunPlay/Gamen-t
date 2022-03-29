using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int cp = -1;

    public bool isCircuit;
    public bool isLinear;

    public void Start()
    {
        isCircuit = false;
        isLinear = false;
        //checkt of hij linear is of circuit is
        if (GameObject.Find("RoadStartFinish(Clone)") == true)
        {
            isCircuit = true;
        }
        else
        {
            isLinear = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<NewCarControll>())
        {
            other.GetComponentInParent<NewCarControll>().checkPoint = transform;
            SetCp(other.GetComponentInParent<PlayerID>());
        }
    }
    void SetCp(PlayerID playerID)
    {
        if (cp == -1)
        {
            cp = playerID.checkPointTime.Count;
        }
        if (cp == playerID.checkPointTime.Count)
        {
            playerID.checkPointTime.Add(playerID.resetTimer);

            if(isLinear == true)
            {
                playerID.checkpointTimeText.text = playerID.resetTimer.ToString("F2");
                playerID.checkpointAnimation.SetTrigger("ShowAnimation");
            }

            playerID.resetTimer = 0;
            
        }
        else
        {
            playerID.OnCheckpoint(cp);
            
        }
    }
}
