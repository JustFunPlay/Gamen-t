using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TestTest : MonoBehaviour
{

    public Camera camera;
    public PlayerInformation playerInfos;

    // Start is called before the first frame update
    void Start()
    {
        AAAAAAAAAAAAAAAAAAAA();

        for (int i = 0; i < GetComponent<UISpawner>().listOfCameras.Count; i++)
        {
            
            
            camera.GetUniversalAdditionalCameraData().cameraStack.Add(GetComponent<UISpawner>().listOfCameras[i].GetComponent<Camera>());
            GetComponent<UISpawner>().listOfCameras[i].SetActive(false);
        }

    }

    public void AAAAAAAAAAAAAAAAAAAA()
    {
        switch (playerInfos.playerSelections.Count)
        {
            case 1:
                GameObject.Find("UI 1 play").GetComponent<Transform>().transform.localScale = new Vector3(1f, 1f, 1f);
                
                GameObject.Find("UI 1 play").GetComponent<Transform>().transform.position = new Vector3(0f, -30f, 100f);
                
                GameObject.Find("UI 1 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                break;
            case 2:
                GameObject.Find("UI 1 play").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                GameObject.Find("UI 2 play").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                
                GameObject.Find("UI 1 play").GetComponent<Transform>().transform.position = new Vector3(-51.4f, -30f, 100f);
                GameObject.Find("UI 2 play").GetComponent<Transform>().transform.position = new Vector3(51.4f, -30f, 100f);

                GameObject.Find("UI 1 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                GameObject.Find("UI 2 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                break;
            case 3:
                GameObject.Find("UI 1 play").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                GameObject.Find("UI 2 play").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                GameObject.Find("UI 3 play").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                
                GameObject.Find("UI 1 play").GetComponent<Transform>().transform.position = new Vector3(-54.1f, 1f, 100f);
                GameObject.Find("UI 2 play").GetComponent<Transform>().transform.position = new Vector3(51.4f, 1f, 100f);
                GameObject.Find("UI 3 play").GetComponent<Transform>().transform.position = new Vector3(0f, -63f, 100f);

                GameObject.Find("UI 1 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                GameObject.Find("UI 2 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                GameObject.Find("UI 3 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                break;
            case 4:
                GameObject.Find("UI 1 play").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                GameObject.Find("UI 2 play").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                GameObject.Find("UI 3 play").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                GameObject.Find("UI 4 play").GetComponent<Transform>().transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                
                GameObject.Find("UI 1 play").GetComponent<Transform>().transform.position = new Vector3(-54.1f, 1f, 100f);
                GameObject.Find("UI 2 play").GetComponent<Transform>().transform.position = new Vector3(51.4f, 1f, 100f);
                GameObject.Find("UI 3 play").GetComponent<Transform>().transform.position = new Vector3(-51.4f, -63f, 100f);
                GameObject.Find("UI 4 play").GetComponent<Transform>().transform.position = new Vector3(51.4f, -63f, 100f);

                GameObject.Find("UI 1 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                GameObject.Find("UI 2 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                GameObject.Find("UI 3 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                GameObject.Find("UI 4 play").GetComponentInChildren<Canvas>().worldCamera = camera;
                break;
            default:
                print("fuck");
                break;
        }
    }
}
