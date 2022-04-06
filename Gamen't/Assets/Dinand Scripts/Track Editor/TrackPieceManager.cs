using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrackPieceManager : EditorCamController
{
    public int selectedTrackPieceIndex;
    public TrackPieceHolder pieceHolder;
    public TrackToLoad toLoad;
    public UpdateTrackInformation updateTrackInformation;
    void OnPlaceTrack()
    {
        if (currentNode.trackPiece)
        {
            OnRemoveTrack();
        }
        currentNode.trackPiece = Instantiate(pieceHolder.trackPieces[selectedTrackPieceIndex].mainTrackPiece, currentNode.transform.position, Quaternion.identity);
        TrackPiece newTrackPiece = new TrackPiece();
        newTrackPiece.gridlocation = currentNode.gridNodeValue;
        newTrackPiece.trackPieceIndex = selectedTrackPieceIndex;
        newTrackPiece.rotation = currentNode.trackPiece.transform.rotation;
        newTrackPiece.position = currentNode.trackPiece.transform.position;
        toLoad.track.trackPieces.Add(newTrackPiece);
        updateTrackInformation.UpdateInfo();
        UpdateTrackInformation.isTested = false;
    }
    void OnRemoveTrack()
    {
        if (worky)
        {
            for (int i = 0; i < toLoad.track.trackPieces.Count; i++)
            {
                if (toLoad.track.trackPieces[i].gridlocation == currentNode.gridNodeValue)
                {
                    toLoad.track.trackPieces.RemoveAt(i);
                }
            }
            if (currentNode.trackPiece)
            {
                Destroy(currentNode.trackPiece);
            }
        }
        updateTrackInformation.UpdateInfo();
        UpdateTrackInformation.isTested = false;
    }
    void OnRotateTrackRight()
    {
        if (currentNode.trackPiece && worky)
        {
            currentNode.trackPiece.transform.Rotate(0, 90, 0);
            for (int i = 0; i < toLoad.track.trackPieces.Count; i++)
            {
                if (toLoad.track.trackPieces[i].gridlocation == currentNode.gridNodeValue)
                {
                    toLoad.track.trackPieces[i].rotation = currentNode.trackPiece.transform.rotation;
                }
            }
        }
        UpdateTrackInformation.isTested = false;
    }
    void OnRotateTrackLeft()
    {
        if (currentNode.trackPiece && worky)
        {
            currentNode.trackPiece.transform.Rotate(0, -90, 0);
            for (int i = 0; i < toLoad.track.trackPieces.Count; i++)
            {
                if (toLoad.track.trackPieces[i].gridlocation == currentNode.gridNodeValue)
                {
                    toLoad.track.trackPieces[i].rotation = currentNode.trackPiece.transform.rotation;
                }
            }
        }
        UpdateTrackInformation.isTested = false;
    }
    void OnFlipTrack()
    {
        print("ye");
        if (currentNode.trackPiece && worky)
        {
            print("flip that shit");
            for (int i = 0; i < toLoad.track.trackPieces.Count; i++)
            {
                if (toLoad.track.trackPieces[i].gridlocation == currentNode.gridNodeValue && (toLoad.track.trackPieces[i].trackPieceIndex == 5 || toLoad.track.trackPieces[i].trackPieceIndex == 6 || toLoad.track.trackPieces[i].trackPieceIndex == 7|| toLoad.track.trackPieces[i].trackPieceIndex == 8 || toLoad.track.trackPieces[i].trackPieceIndex == 10 || toLoad.track.trackPieces[i].trackPieceIndex == 12))
                {
                    Destroy(currentNode.trackPiece);
                    if (toLoad.track.trackPieces[i].isAlternate)
                    {
                        toLoad.track.trackPieces[i].isAlternate = false;
                        currentNode.trackPiece = Instantiate(pieceHolder.trackPieces[selectedTrackPieceIndex].mainTrackPiece, currentNode.transform.position, toLoad.track.trackPieces[i].rotation);
                    }
                    else
                    {
                        toLoad.track.trackPieces[i].isAlternate = true;
                        currentNode.trackPiece = Instantiate(pieceHolder.trackPieces[selectedTrackPieceIndex].altTrackPiece, currentNode.transform.position, toLoad.track.trackPieces[i].rotation);
                    }

                }
            }
        }
        UpdateTrackInformation.isTested = false;
    }
}
