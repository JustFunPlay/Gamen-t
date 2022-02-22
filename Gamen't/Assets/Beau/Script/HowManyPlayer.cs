using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HowManyPlayer : MonoBehaviour
{

    public PlayerInformation fuckDINAND;


    public void OnePlayers()
    {
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        SceneManager.LoadScene(1);
    }
    public void TwoPlayers()
    {
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        SceneManager.LoadScene(1);
    }
    public void ThreePlayers()
    {
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        SceneManager.LoadScene(1);
    }
    public void FourPlayers()
    {
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        fuckDINAND.playerSelections.Add(new PlayerSelection());
        SceneManager.LoadScene(1);
    }
}
