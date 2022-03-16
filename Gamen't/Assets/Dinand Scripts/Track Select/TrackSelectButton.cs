using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrackSelectButton : MonoBehaviour, ISelectHandler
{
    public int index;

    public void OnSelect(BaseEventData eventData)
    {


        GetComponentInParent<TrackEditSelectMen>().LoadCustomTrack(index);
    }


}
