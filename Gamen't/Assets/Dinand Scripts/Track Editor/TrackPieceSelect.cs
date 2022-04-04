using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPieceSelect : MonoBehaviour
{
    public int trackPieceIndex;
    public TrackPieceManager pieceManager;

    public void SelectTrackPiece()
    {
        pieceManager.selectedTrackPieceIndex = trackPieceIndex;
    }
}
