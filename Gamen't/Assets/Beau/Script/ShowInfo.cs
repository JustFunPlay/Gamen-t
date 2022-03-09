using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShowInfo : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject howManyPlayers;
    public void OnSelect(BaseEventData eventData)
    {
        howManyPlayers.SetActive(true);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        print("aaaaaah");
        howManyPlayers.SetActive(false);
    }
}
