using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TrackEditSelectMen : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public TrackToLoad trackToLoad;
    public TrackInfo trackInfo;
    public ListOfAllTracks allTracks;
    public int ah;

    public Text description;
    public Text trackType;
    public GameObject editBtn;
    public GameObject infoTrack;


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

    public void LoadBaseTrack()
    {
        

        trackToLoad.track = allTracks.defaultTracks[ah];
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
        SceneManager.LoadScene(2);
    }
    public void EnterEditor()
    {
        SceneManager.LoadScene(4);
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
    public void OnSelect(BaseEventData eventData)
    {

        infoTrack.SetActive(true);
        if (infoTrack == true)
        {
            LoadBaseTrack();
        }

    }





    public void OnDeselect(BaseEventData eventData)
    {

        infoTrack.SetActive(false);
    }
}
