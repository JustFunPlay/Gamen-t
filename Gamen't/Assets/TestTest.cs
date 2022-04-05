using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTest : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GetComponent<UISpawner>().listOfCameras.Count; i++)
        {
            //GetComponent<UISpawner>().listOfCameras[i].GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
        }
        //camera.
    }


}
