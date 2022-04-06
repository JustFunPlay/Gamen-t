using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CupRace : MonoBehaviour
{
    public TrackToLoad gettingTrack;
    public PlayerInformation trackHolder;

    public Text chooseTracksText;
    public Button cupRaceButton;

    public void Start()
    {
        ResetData();
    }
    // dit is gedaan met een toggle, als je wil kan het ook anders...
    public void OnBoolActivate()
    {
        if (trackHolder.raceCupBool == false)
        {
            trackHolder.raceCupBool = true;
            chooseTracksText.text = "Choose your cups!";
        }
        else
        {
            ResetData();
            trackHolder.raceCupBool = false;
            chooseTracksText.text = "Activate Cup!";
        }
    }

    //wanneer de speler op een kaart klikt bij raceSelect
    public void OnSelected()
    {
        if(trackHolder.raceCupBool == true)
        {
            if(trackHolder.counter < trackHolder.trackInfo.Length)
            {
                trackHolder.trackInfo[trackHolder.counter] = gettingTrack.track;
                trackHolder.counter++;
            }
            if (trackHolder.counter == trackHolder.trackInfo.Length)
            {
                SceneManager.LoadScene(2);
            }
        }

    }
    public void ResetData()
    {
        for (int i = 0; i < trackHolder.trackInfo.Length; i++)
        {
            trackHolder.trackInfo[i] = null;
        }
        trackHolder.counter = 0;
        //trackHolder.nextNumberRace = 0;
        trackHolder.raceCupBool = false;
    }
    public void OnSelectedButton()
    {
        if (trackHolder.raceCupBool == true)
        {
            if (trackHolder.counter < trackHolder.trackInfo.Length)
            {
                trackHolder.trackInfo[trackHolder.counter] = gettingTrack.track;
                trackHolder.counter++;
            }
        }
    }
    public void TracksSelectedCheck()
    {

    }
}
