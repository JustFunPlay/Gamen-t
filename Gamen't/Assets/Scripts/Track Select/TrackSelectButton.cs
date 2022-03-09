using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSelectButton : MonoBehaviour
{
    public int index;

    public void OnPress()
    {
        GetComponentInParent<TrackEditSelectMen>().LoadCustomTrack(index);
    }
}
