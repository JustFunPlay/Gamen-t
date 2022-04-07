using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class asdas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler

{
    public Text a;
    public Color b;
    public Color c;

    public void OnPointerEnter(PointerEventData eventData)
    {
        a.color = b;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        a.color = c;
    }
    public void OnClickButton()
    {
        a.color = c;
    }

    public void OnSelect(BaseEventData eventData)
    {
        a.color = b;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        a.color = c;
    }


}
