using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    public PlayerInformation playerInfo; 

    public int playerIdNumber;

    public int totalTimesThroughFinish = 1;
    public bool canStart;
    public bool canFinish;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint begin")
        {
            canFinish = true;
        }
        if (other.gameObject.tag == "CheckPoint meanwhile")
        {
            canFinish = false;
        }
        if (other.gameObject.tag == "CheckPoint end")
        {
            if(canFinish == true)
            {
                totalTimesThroughFinish++;
                canFinish = false;
                if (totalTimesThroughFinish == playerInfo.maxLaps)
                {

                    
                }

            }
        }



    }

}
