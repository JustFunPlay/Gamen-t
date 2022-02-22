using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowManyPlayer : MonoBehaviour
{
    public PlayerInformation playerInfo;

    public void TwoPlayers()
    {
        playerInfo.playerSelections.Capacity=2;
    }
    public void ThreePlayers()
    {
        playerInfo.playerSelections.Capacity = 3;
    }
    public void FourPlayers()
    {
        playerInfo.playerSelections.Capacity = 4;
    }
}
