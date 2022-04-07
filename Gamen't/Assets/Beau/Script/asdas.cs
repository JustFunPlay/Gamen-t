using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class asdas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

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

}
