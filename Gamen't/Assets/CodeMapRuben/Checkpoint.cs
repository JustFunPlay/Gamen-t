using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int cp = -1;
    
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
            //playerID.checkpointTimeText.text = playerID.resetTimer.ToString("F2");
            playerID.resetTimer = 0;
            //playerID.checkpointAnimation.SetTrigger("ShowAnimation");
        }
        else
        {
            playerID.OnCheckpoint(cp);
            
        }
    }
}
