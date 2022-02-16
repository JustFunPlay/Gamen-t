using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackLoader : MonoBehaviour
{
    public TrackToLoad trackToLoad;
    void Start()
    {
        for (int i = 0; i < trackToLoad.track.trackPieces.Count; i++)
        {
            Instantiate(trackToLoad.track.trackPieces[i].trackPiece, trackToLoad.track.trackPieces[i].position, trackToLoad.track.trackPieces[i].rotation);
        }
    }
}
