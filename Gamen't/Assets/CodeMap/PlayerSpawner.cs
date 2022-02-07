using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{

    public PlayerInformation playerInfo;

    public GameObject player;
    public Vector3[] playerSpawning;
    public int i;

    public InputActionProperty joinAction { get; set; }
    public bool joiningEnabled { get; }
    public Rect splitScreenArea { get; }
    public bool splitScreen { get; }

    // Start is called before the first frame update
    void Start()
    {
        playerInfo.totalPlayers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerSpawn()
    {
        
        if (i <= 3)
        {
            Instantiate(player, playerSpawning[0], Quaternion.identity);
            i++;
            playerInfo.totalPlayers++;
        }
        else
        {
            print("too many players");
        }

    }
    public void PlayerDespawn()
    {
        Destroy(gameObject);
    }
}
