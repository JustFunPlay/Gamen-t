using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSouns : MonoBehaviour
{

    private void Update()
    {
        GetComponentInChildren<Sound>().brrSounds.Stop();
    }


}
