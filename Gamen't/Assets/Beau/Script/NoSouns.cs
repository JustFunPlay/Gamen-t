using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSouns : MonoBehaviour
{

    private void Start()
    {
        GetComponentInChildren<Sound>().brrSounds.Stop();

    }


}
