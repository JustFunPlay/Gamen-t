using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrackPieceManager : EditorCamController
{
    public GameObject selectedTrackPiece;
    public TrackToLoad toLoad;
    void OnPlaceTrack()
    {
        if (selectedTrackPiece)
        {
            if (currentNode.trackPiece)
            {
                OnRemoveTrack();
            }
            currentNode.trackPiece = Instantiate(selectedTrackPiece, currentNode.transform.position, Quaternion.identity);
            TrackPiece newTrackPiece = new TrackPiece();
            newTrackPiece.gridlocation = currentNode.gridNodeValue;
            newTrackPiece.trackPiece = selectedTrackPiece;
            newTrackPiece.rotation = currentNode.trackPiece.transform.rotation;
            newTrackPiece.position = currentNode.trackPiece.transform.position;
            newTrackPiece.xScale = 1;
            toLoad.track.trackPieces.Add(newTrackPiece);
        }
    }
    void OnRemoveTrack()
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
    void OnRotateTrackRight()
    {
        if (currentNode.trackPiece)
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
    }
    void OnRotateTrackLeft()
    {
        if (currentNode.trackPiece)
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
    }
    void OnFlipTrack()
    {
        print("ye");
        if (currentNode.trackPiece)
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
    }
}
