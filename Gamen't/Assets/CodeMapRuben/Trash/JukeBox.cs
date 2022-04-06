using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class JukeBox : MonoBehaviour
{
    public VideoPlayer soundProducer;
    public string putLinkHere;
    public InputField urlInfo;

    void Start() 
    {
        RefreshMusic();
    }
    public void RefreshMusic()
    {
        putLinkHere = urlInfo.text;
        soundProducer.url = putLinkHere;
        soundProducer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        soundProducer.Prepare();
    }

}
