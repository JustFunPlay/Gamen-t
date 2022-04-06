using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Track Info", menuName = "ScriptableObjects/New Track Info")]
public class TrackInfo : ScriptableObject
{
    public string trackName;
    public List<TrackPiece> trackPieces;
    public Leaderboard[] leaderboards = new Leaderboard[5];
    public int numberOfLaps;
    public string description;
    public TrackType trackType;
}

[System.Serializable]
public class TrackPiece
{
    public Vector3 position;
    public Quaternion rotation;
    public int trackPieceIndex;
    public bool isAlternate;
    public int gridlocation;
}
[System.Serializable]
public class Leaderboard
{
    public string racerName;
    public float timeInSec;
    
    public Leaderboard(string racerName_, float timeInSec_)
    {
        this.racerName = racerName_;
        this.timeInSec = timeInSec_;
        
    }
    public Leaderboard()
    {
        racerName = null;
        timeInSec = 0;
    }
}
[System.Serializable]
public enum TrackType
{
    Circuit,
    Linear
}