using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShowInfo : MonoBehaviour, ISelectHandler
{

    public GameObject infosTrack;
    public TrackEditSelectMen trackEditSelection;
    public int baseTrack;
    public EventSystem raceselectEventSystem;
    public GameObject buttonRace;



    public void OnSelect(BaseEventData eventData)
    {

        trackEditSelection = GetComponentInParent<TrackEditSelectMen>();        
        infosTrack.SetActive(true);
        trackEditSelection.LoadBaseTrack(baseTrack);


    }

    public void PressedButton()
    {
        raceselectEventSystem.SetSelectedGameObject(buttonRace);
    }


}
