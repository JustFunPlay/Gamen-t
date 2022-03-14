using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LeaderBoardInfo", menuName = "ScriptableObject/LeaderBoardInfo")]
public class ScriptableLeaderboardInfo : ScriptableObject
{
    public List<Leaderboard> leaderboard;

        
}

