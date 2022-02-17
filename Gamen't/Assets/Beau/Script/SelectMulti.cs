using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SelectMulti : MonoBehaviour, ISelectHandler
{
    public GameObject howManyPlayers;



    public void OnSelect(BaseEventData eventData)
    {
        if(eventData.selectedObject.tag == "Multi")
        {
            howManyPlayers.SetActive(true);
        }
        else
        {
            howManyPlayers.SetActive(false);
        }



    }


}
