using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TrackPieceHolder", menuName = "ScriptableObjects/TrackPieceHolder")]
public class TrackPieceHolder : ScriptableObject
{
    public TrackPieces[] trackPieces;
    //fuck u unity
}
[System.Serializable]
public class TrackPieces
{
    public GameObject mainTrackPiece;
    public GameObject altTrackPiece;
}
