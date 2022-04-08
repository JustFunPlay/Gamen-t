using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;

public class SaveTracks : MonoBehaviour
{
    public TrackToLoad toLoad;
    public Image image;
    public Text text;
    bool canClick = true;
    public void SaveTrack()
    {
        if (canClick)
        {
            if (UpdateTrackInformation.isTested)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TrackInfo));
                var encoding = System.Text.Encoding.GetEncoding("UTF-8");
                StreamWriter stream = new StreamWriter(Application.dataPath + "/StreamingAssets/XML/" + toLoad.track.trackName + ".xml", false, encoding);
                serializer.Serialize(stream, toLoad.track);
                stream.Close();
                StartCoroutine(saved());
            }
            else
            {
                StartCoroutine(Error());
            }
        }
    }
    IEnumerator saved()
    {
        canClick = false;
        image.color = Color.green;
        text.text = "Track Saved";
        yield return new WaitForSeconds(1f);
        image.color = Color.white;
        text.text = "Save";
        canClick = true;
    }
    IEnumerator Error()
    {
        canClick = false;
        image.color = Color.red;
        text.text = "Track Edited";
        yield return new WaitForSeconds(0.5f);
        text.text = "Test First";
        yield return new WaitForSeconds(0.5f);
        image.color = Color.white;
        text.text = "Save";
        canClick = true;
    }
}
