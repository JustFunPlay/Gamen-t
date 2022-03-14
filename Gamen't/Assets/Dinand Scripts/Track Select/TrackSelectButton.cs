using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrackSelectButton : MonoBehaviour, ISelectHandler
{
    public int index;
    public GameObject infosTrack;
    public void OnSelect(BaseEventData eventData)
    {

        infosTrack.SetActive(true);
        GetComponentInParent<TrackEditSelectMen>().LoadCustomTrack(index);
    }


}
