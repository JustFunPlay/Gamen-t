using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public PlayerInformation playerInfo;

    public GameObject[] player;
    public Vector3[] playerSpawning;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerSpawn()
    {
        Instantiate(player[i], playerSpawning[i], Quaternion.identity);
        //Instantiate(GetComponent<PlayerInformation>().playersGameObjects,GetComponent<PlayerInformation>().playerSpawn, Quaternion.identity);
        if (i <= 3)
        {
            i++;
            playerInfo.totalPlayers++;
        }
        else
        {
            print("to many players");
        }

    }
}
