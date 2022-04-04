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
            FileStream stream = new FileStream(Application.dataPath + "/StreamingFiles/XML/" + toLoad.track.trackName + ".xml", FileMode.Create);
            serializer.Serialize(stream, toLoad.track);
            stream.Close();
        }
    }
}
