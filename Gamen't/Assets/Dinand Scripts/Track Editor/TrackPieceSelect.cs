using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPieceSelect : MonoBehaviour
{
    public GameObject trackPiece;
    public TrackPieceManager pieceManager;

    public void SelectTrackPiece()
    {
        pieceManager.selectedTrackPiece = trackPiece;
    }
}
