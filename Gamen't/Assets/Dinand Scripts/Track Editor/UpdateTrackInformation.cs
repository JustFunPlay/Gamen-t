using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTrackInformation : MonoBehaviour
{
    public TrackToLoad track;
    public Text lapText;
    public GameObject addLapBtn;
    public GameObject rmvLapBtn;
    public InputField trackNameText;
    public InputField descriptionText;
    public Text trackTypeText;
    public static bool isTested;

    void Start()
    {
        CheckForCircuit();
        trackNameText.text = track.track.trackName;
        descriptionText.text = track.track.description;
    }

    public void UpdateInfo()
    {
        CheckForCircuit();
        track.track.trackName = trackNameText.text;
        track.track.description = descriptionText.text;
    }
    void CheckForCircuit()
    {
        GameObject[] finishlines = GameObject.FindGameObjectsWithTag("CheckPoint end");
        if (finishlines.Length > 1)
        {
            track.track.numberOfLaps = 1;
            track.track.trackType = TrackType.Linear;
            addLapBtn.SetActive(false);
            rmvLapBtn.SetActive(false);
        }
        else
        {
            track.track.trackType = TrackType.Circuit;
            addLapBtn.SetActive(true);
            rmvLapBtn.SetActive(true);
        }
        trackTypeText.text = track.track.trackType.ToString();
        lapText.text = track.track.numberOfLaps.ToString();
    }

    public void ChangeLaps(int lapMod)
    {
        track.track.numberOfLaps += lapMod;
        if (track.track.numberOfLaps == 0)
        {
            track.track.numberOfLaps = 99;
        }
        else if (track.track.numberOfLaps == 100)
        {
            track.track.numberOfLaps = 1;
        }
        lapText.text = track.track.numberOfLaps.ToString();
    }
}
