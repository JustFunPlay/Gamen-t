using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    public AudioSource brrSounds;
    public float maxPitch ;
    public float minPitch;
    public float pitch;
    public NewCarControll newCarControll;




    public void Update()
    {
        pitch = newCarControll.speedRead/140;


        if (pitch < minPitch)
        {
            brrSounds.pitch = minPitch;
        }
        else if (pitch > maxPitch)
        {
            brrSounds.pitch = maxPitch;
        }
        else
        {
            brrSounds.pitch = pitch;
        }
        

        
    }
}
