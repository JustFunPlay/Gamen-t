using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChangeForINfo : MonoBehaviour
{
    public Sprite[] premadeImages;
    public GameObject trackInfoScreen;
    public Sprite stockImage;
    public bool returnStock;

    public void PressedButton(int i)
    {


            trackInfoScreen.GetComponentInChildren<Image>().sprite = premadeImages[i];
            returnStock = true;
            A();

    }
    public void A()
    {

        if (returnStock == true)
        {
            trackInfoScreen.GetComponentInChildren<Image>().sprite = stockImage;
        }
    }
    


}
