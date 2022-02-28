using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLoader : MonoBehaviour
{
    public TrackToLoad trackToLoad;
    public bool isEditorScene;
    void Start()
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
                        node.trackPiece = Instantiate(trackToLoad.track.trackPieces[i].trackPiece, trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < trackToLoad.track.trackPieces.Count; i++)
            {
                 Instantiate(trackToLoad.track.trackPieces[i].trackPiece, trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);
            }
        }
    }
}
