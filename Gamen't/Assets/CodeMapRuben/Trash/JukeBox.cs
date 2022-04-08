using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class JukeBox : MonoBehaviour
{
    public PlayerInformation playerInfo;

    public bool allowPlay;

    public VideoPlayer soundProducer;
    public InputField urlInfo;

    public AudioSource mainSong;

    //https://unity-youtube-dl-server.herokuapp.com/watch?v=dQw4w9WgXcQ

    void Start()
    {        
        //als je iets hebt ingevuld bij de JukeBox bool dan gaat de if statement af
        if (playerInfo.activateJukeBox == true)
        {
            //mainSong.Stop();
            //RefreshMusic();
        }
        
    }
    public void CalculateString()
    {
        mainSong.Stop();

        if (urlInfo.text.Contains("www.youtube.com"))
        {
            playerInfo.musicToLoad = urlInfo.text.ToString().Replace("www.youtube.com", "unity-youtube-dl-server.herokuapp.com");
        }
        if (urlInfo.text.Contains("youtu.be"))
        {
            playerInfo.musicToLoad = urlInfo.text.ToString().Replace("youtu.be/", "unity-youtube-dl-server.herokuapp.com/watch?v=");
        }
        RefreshMusic();
    }
    public void RefreshMusic()
    {
        if(allowPlay == true)
        {


            soundProducer.url = playerInfo.musicToLoad;
            
            
                
            soundProducer.audioOutputMode = VideoAudioOutputMode.AudioSource;
            soundProducer.EnableAudioTrack(0, true);
            soundProducer.Prepare();
            
        }
    }
    public void ToggleJukeBox()
    {
        if(playerInfo.activateJukeBox == false)
        {
            playerInfo.activateJukeBox = true;
        }
        else
        {
            playerInfo.activateJukeBox = false;
        }
  
    }

}
