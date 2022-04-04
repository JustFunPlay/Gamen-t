using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupRace : MonoBehaviour
{
    public TrackToLoad gettingTrack;
    public PlayerInformation trackHolder;

    public Text chooseTracksText;
    public Button cupRaceButton;

    public int counter;

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
            

            if(counter < trackHolder.trackInfo.Length)
            {
                trackHolder.trackInfo[counter] = gettingTrack.track;
                counter++;
            }
            if(counter == trackHolder.trackInfo.Length)
            {
                cupRaceButton.interactable = true;
            }
        }

    }
    public void ResetData()
    {
        for (int i = 0; i < trackHolder.trackInfo.Length; i++)
        {
            trackHolder.trackInfo[i] = null;
        }
        counter = 0;
        cupRaceButton.interactable = false;
        trackHolder.nextNumberRace = 0;
        trackHolder.raceCupBool = false;
    }
}
