using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerID : MonoBehaviour
{
    public PlayerInformation playerInfos;

    public int playerIdNumber;
    // Start is called before the first frame update
    void Start()
    {
        playerIdNumber = playerInfos.totalPlayers;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
