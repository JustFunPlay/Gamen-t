using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackInfo : ScriptableObject
{
    public string trackName;
    public List<TrackPiece> trackPieces;
    public Leaderboard[] leaderboards = new Leaderboard[5];
    public int numberOfLaps;
}

[System.Serializable]
public class TrackPiece
{
    public Vector3 position;
    public Quaternion rotation;
    public GameObject trackPiece;
}
[System.Serializable]
public class Leaderboard
{
    public string racerName;
    public float timeInSec;
}