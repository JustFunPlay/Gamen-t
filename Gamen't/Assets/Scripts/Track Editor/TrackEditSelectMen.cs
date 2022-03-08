using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrackEditSelectMen : MonoBehaviour
{
    public TrackToLoad trackToLoad;
    public TrackInfo trackInfo;
    public ListOfAllTracks allTracks;

    public Text description;
    public Text trackType;
    public GameObject editBtn;

    public Transform[] transforms;
    public GameObject buttonPrefab;

    void Start()
    {
        UpdateTrackList();
    }

    public void NewTrack()
    {
        //trackToLoad.track = new TrackInfo(ScriptableObject.CreateInstance<TrackInfo>());
        trackToLoad.track = (TrackInfo)Instantiate(trackInfo);
        //SceneManager.LoadScene(1);
    }

    public void LoadBaseTrack(int track)
    {
        trackToLoad.track = allTracks.defaultTracks[track];
        editBtn.SetActive(false);
        description.text = trackToLoad.track.description;
        if (trackToLoad.track.trackType == TrackType.Circuit)
        {
            trackType.text = "Circuit";
        }
        else
        {
            trackType.text = "Linear";
        }
    }
    public void LoadCustomTrack(int track)
    {
        trackToLoad.track = allTracks.trackInfos[track];
        editBtn.SetActive(true);
        description.text = trackToLoad.track.description;
        if (trackToLoad.track.trackType == TrackType.Circuit)
        {
            trackType.text = "Circuit";
        }
        else
        {
            trackType.text = "Linear";
        }
    }
    public void EnterRace()
    {
        //SceneManager.LoadScene(0);
    }
    public void EnterEditor()
    {
        //SceneManager.LoadScene(1);
    }
    public void UpdateTrackList()
    {
        for (int i = 0; i < allTracks.trackInfos.Count; i++)
        {
            if (i < transforms.Length)
            {
                GameObject newButton = Instantiate(buttonPrefab, transforms[i].position, transforms[i].rotation, transforms[i]);
                newButton.GetComponentInChildren<Text>().text = allTracks.trackInfos[i].trackName;
                newButton.GetComponent<TrackSelectButton>().index = i;
            }
        }
    }
}
