using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackEditSelectMen : MonoBehaviour
{
    public TrackToLoad trackToLoad;

    public void NewTrack()
    {
        trackToLoad.track = ScriptableObject.Instantiate(ScriptableObject.CreateInstance<TrackInfo>());
        SceneManager.LoadScene(1);
    }
}
