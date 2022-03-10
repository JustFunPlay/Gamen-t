using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShowInfo : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    public GameObject infosTrack;
    public TrackEditSelectMen tets;

    public void OnSelect(BaseEventData eventData)
    {

        infosTrack.SetActive(true);
        tets.LoadBaseTrack();
    }
    public void OnDeselect(BaseEventData eventData)
    {

        infosTrack.SetActive(false);
    }

}
