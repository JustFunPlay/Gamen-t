using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimmyTheCheatEngine : MonoBehaviour {
    private bool cheatsActive = false;
    private string sceneName = "tracktestscene";
    private GameObject[] players;

    private void Awake() {
        DontDestroyOnLoad(this);
    }

    private void Start() {
        players = new GameObject[0];
    }

    private void Update() {
        if (CompareScene(sceneName)) {
            if (!cheatsActive) {
                AllowCheats();
            }
        }
    }

    private void AllowCheats() {
        if (players.Length < 1) {
            players = FindPlayers();
            return;
        } else {
            //InvokeRepeating("ChangeCarSize", 1f, .25f);
            cheatsActive = true;
        }
    }

    private bool CompareScene(string sceneName) {
        if (SceneManager.GetActiveScene().name == sceneName) {
            return true;
        } else {
            return false;
        }
    }

    private GameObject[] FindPlayers() {
        return GameObject.FindGameObjectsWithTag("Player");
    }

    private void ChangeCarSize() {

        foreach (GameObject player in players) {
            //Debug.Log("Change Size + " + player.transform.name);

            Transform playerCar = player.transform.Find("Car Toyota GT68");

            float minSize = 0.1f;
            float maxSize = 2f;
            playerCar.transform.localScale = new Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), Random.Range(minSize, maxSize));
        }
    }
}
