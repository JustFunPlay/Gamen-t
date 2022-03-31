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
                        node.trackPiece.transform.localScale = new Vector3(trackToLoad.track.trackPieces[i].xScale, 1, 1f);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < trackToLoad.track.trackPieces.Count; i++)
            {
                GameObject blah = Instantiate(trackToLoad.track.trackPieces[i].trackPiece, trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);
                blah.transform.localScale = new Vector3(trackToLoad.track.trackPieces[i].xScale, 1, 1);
            }
        }
    }
}
