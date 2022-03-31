using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShowInfo : MonoBehaviour
{

    public GameObject infosTrack;
    public TrackEditSelectMen trackEditSelection;
    public int baseTrack;





    public void OnSelect()
    {
        infosTrack.SetActive(true);
        GetComponentInParent<TrackEditSelectMen>().LoadBaseTrack(baseTrack);
    }




}
