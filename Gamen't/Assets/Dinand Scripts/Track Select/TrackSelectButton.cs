using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrackSelectButton : MonoBehaviour
{

    public int index;

    public void OnSelect()
    {
        GetComponentInParent<TrackEditSelectMen>().LoadCustomTrack(index);
    }


}
