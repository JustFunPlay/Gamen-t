using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HowManyPlayer : MonoBehaviour
{

    public PlayerInformation carSelectCanvas;
    public PlayerInformation playerCars;
    public PlayerSelection canvasSelection;
    public PlayerSelection carSelection;

    private void Start()
    {
        carSelectCanvas.playerSelections.Clear();
        playerCars.playerSelections.Clear();
        playerCars.playerSelections.Add(new PlayerSelection(carSelection));
        carSelectCanvas.playerSelections.Add(canvasSelection);
    }




    public void LoadPlayers(int numOfPlayers)
    {
        for (int i = 1; i < numOfPlayers; i++)
        {
            playerCars.playerSelections.Add(new PlayerSelection(carSelection));
            carSelectCanvas.playerSelections.Add(canvasSelection);
        }
        SceneManager.LoadScene(1);
    }
}
