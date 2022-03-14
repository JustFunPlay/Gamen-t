using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List of tracks", menuName = "ScriptableObjects/List of Tracks")]
public class ListOfAllTracks : ScriptableObject
{
    public TrackInfo[] defaultTracks;
    public List<TrackInfo> trackInfos = new List<TrackInfo>();
}
