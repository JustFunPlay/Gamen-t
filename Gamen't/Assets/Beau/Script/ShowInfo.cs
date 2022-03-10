using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShowInfo : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    public GameObject infosTrack;
    public TrackEditSelectMen trackEditSelection;
    public int baseTrack;

    public void OnSelect(BaseEventData eventData)
    {

        infosTrack.SetActive(true);
        trackEditSelection.LoadBaseTrack(baseTrack);
    }
    public void OnDeselect(BaseEventData eventData)
    {

        infosTrack.SetActive(false);
    }

}
