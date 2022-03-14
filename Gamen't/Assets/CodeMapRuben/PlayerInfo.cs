using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public GameObject camaraSpawning;

    public Transform thisGameobject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate<GameObject>(camaraSpawning, thisGameobject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
