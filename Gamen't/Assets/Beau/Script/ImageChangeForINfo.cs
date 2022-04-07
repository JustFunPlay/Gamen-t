using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChangeForINfo : MonoBehaviour
{
    public Sprite[] premadeImages;
    public GameObject trackInfoScreen;

    public void PressedButton(int i)
    {
        trackInfoScreen.GetComponentInChildren<Image>().sprite = premadeImages[i];
    }


}
