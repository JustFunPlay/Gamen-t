using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TrackLoader : MonoBehaviour
{
    public TrackToLoad trackToLoad;
    public TrackPieceHolder pieceHolder;
    public bool isEditorScene;
    void Awake()
    {
        if (isEditorScene)
        {
            NodeInfo[] nodeInfos = FindObjectsOfType<NodeInfo>();
            foreach (NodeInfo node in nodeInfos)
            {
                for (int i = 0; i < trackToLoad.track.trackPieces.Count; i++)
                {
                    if (trackToLoad.track.trackPieces[i].gridlocation == node.gridNodeValue)
                    {
                        if (trackToLoad.track.trackPieces[i].isAlternate)
                        {
                            node.trackPiece = Instantiate(pieceHolder.trackPieces[trackToLoad.track.trackPieces[i].trackPieceIndex].altTrackPiece, trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);

                        }
                        else
                        {
                            node.trackPiece = Instantiate(pieceHolder.trackPieces[trackToLoad.track.trackPieces[i].trackPieceIndex].mainTrackPiece, trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);
                        }
                    }
                }
            }
            EditorUtility.SetDirty(trackToLoad.track);
        }
        else
        {
            for (int i = 0; i < trackToLoad.track.trackPieces.Count; i++)
            {
                if (trackToLoad.track.trackPieces[i].isAlternate || (trackToLoad.track.trackPieces[i].trackPieceIndex == 0 && trackToLoad.track.trackType == TrackType.Linear))
                {
                    Instantiate(pieceHolder.trackPieces[trackToLoad.track.trackPieces[i].trackPieceIndex].altTrackPiece, trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);

                }
                else
                {
                    Instantiate(pieceHolder.trackPieces[trackToLoad.track.trackPieces[i].trackPieceIndex].mainTrackPiece, trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);
                }
            }
        }
    }
}
