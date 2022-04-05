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
        currentNode.trackPiece = Instantiate(pieceHolder.trackPieces[selectedTrackPieceIndex], currentNode.transform.position, Quaternion.identity);
        TrackPiece newTrackPiece = new TrackPiece();
        newTrackPiece.gridlocation = currentNode.gridNodeValue;
        newTrackPiece.trackPieceIndex = selectedTrackPieceIndex;
        newTrackPiece.rotation = currentNode.trackPiece.transform.rotation;
        newTrackPiece.position = currentNode.trackPiece.transform.position;
        newTrackPiece.xScale = 1;
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
            currentNode.trackPiece.transform.localScale = new Vector3(currentNode.trackPiece.transform.localScale.x * -1, currentNode.trackPiece.transform.localScale.y, currentNode.trackPiece.transform.localScale.z);
            for (int i = 0; i < toLoad.track.trackPieces.Count; i++)
            {
                if (toLoad.track.trackPieces[i].gridlocation == currentNode.gridNodeValue)
                {
                    toLoad.track.trackPieces[i].xScale = currentNode.trackPiece.transform.localScale.x;
                }
            }
        }
        UpdateTrackInformation.isTested = false;
    }
}
