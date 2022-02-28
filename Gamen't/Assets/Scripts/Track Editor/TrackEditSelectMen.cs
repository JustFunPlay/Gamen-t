using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackEditSelectMen : MonoBehaviour
{
    public TrackToLoad trackToLoad;
    public TrackInfo trackInfo;

    public void NewTrack()
    {
        //trackToLoad.track = new TrackInfo(ScriptableObject.CreateInstance<TrackInfo>());
        trackToLoad.track = (TrackInfo)Instantiate(trackInfo);
        SceneManager.LoadScene(1);
    }
}
