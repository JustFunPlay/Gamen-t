using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    public int playerIdNumber;
    public int totalTimesThroughFinish = 1;

    public bool canStart;
    public bool canFinish;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            canStart = true;
        }



    }

}
