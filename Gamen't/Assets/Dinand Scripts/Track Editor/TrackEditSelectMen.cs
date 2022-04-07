using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
public class TrackEditSelectMen : MonoBehaviour
{
    public TrackToLoad trackToLoad;
    public TrackInfo trackInfo;
    public ListOfAllTracks allTracks;


    public Text description;
    public Text trackType;
    public GameObject editBtn;
    public GameObject infoTrack;


    public Transform[] transforms;
    public GameObject buttonPrefab;

    private void Awake()
    {
        allTracks.trackInfos.Clear();
        string[] filesStrings = Directory.GetFiles(Application.dataPath + "/StreamingAssets/XML/");
        foreach (string fileString in filesStrings)
        {
            if (fileString.Contains(".xml") && !fileString.Contains("xml.meta"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TrackInfo));
                StreamReader stream = new StreamReader(fileString);
                TrackInfo newTrack = ScriptableObject.CreateInstance<TrackInfo>();
                newTrack = serializer.Deserialize(stream) as TrackInfo;
                allTracks.trackInfos.Add(newTrack);
                stream.Close();
                print(fileString);
            }
        }
    }
    
    public void DeleteTrack()
    {
        
    }

    void Start()
    {
        UpdateTrackInformation.isTested = true;
        trackInfo.description = null;
        trackInfo.numberOfLaps = 3;
        trackInfo.trackName = "New Track";
        trackInfo.trackPieces.Clear();
        UpdateTrackList();
    }

    public void NewTrack()
    {
        //trackToLoad.track = new TrackInfo(ScriptableObject.CreateInstance<TrackInfo>());
        trackToLoad.track = trackInfo;
        trackToLoad.track.trackName = "New Track";
        SceneManager.LoadScene(4);
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
                newButton.GetComponent<ShowInfo>().infosTrack =  infoTrack;
            }
        }
    }
}






