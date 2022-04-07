using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class SaveTracks : MonoBehaviour
{
    public TrackToLoad toLoad;

    public void SaveTrack()
    {
        if (UpdateTrackInformation.isTested)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TrackInfo));
            var encoding = System.Text.Encoding.GetEncoding("UTF-8"); 
            StreamWriter stream = new StreamWriter(Application.dataPath + "/StreamingAssets/XML/" + toLoad.track.trackName + ".xml", false, encoding);
            serializer.Serialize(stream, toLoad.track);
            stream.Close();
        }
    }
}
