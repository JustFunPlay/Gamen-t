using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtest : MonoBehaviour
{
    public AudioSource brrSounds;
    public float maxPitch ;
    public float minPitch;
    public float pitch;
    public NewCarControll newCarControll;
    // Update is called once per frame
    void Update()
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
        )

        
    }
}
