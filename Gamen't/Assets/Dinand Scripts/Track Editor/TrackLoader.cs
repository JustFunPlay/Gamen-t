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
                        node.trackPiece = Instantiate(pieceHolder.trackPieces[trackToLoad.track.trackPieces[i].trackPieceIndex], trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);
                        node.trackPiece.transform.localScale = new Vector3(trackToLoad.track.trackPieces[i].xScale, 1, 1f);
                    }
                }
            }
            EditorUtility.SetDirty(trackToLoad.track);
        }
        else
        {
            for (int i = 0; i < trackToLoad.track.trackPieces.Count; i++)
            {
                GameObject blah = Instantiate(pieceHolder.trackPieces[trackToLoad.track.trackPieces[i].trackPieceIndex], trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);
                blah.transform.localScale = new Vector3(trackToLoad.track.trackPieces[i].xScale, 1, 1);
            }
        }
    }
}
