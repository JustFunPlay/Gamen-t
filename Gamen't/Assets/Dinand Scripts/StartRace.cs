using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartRace : MonoBehaviour
{
    public List<NewCarControll> playerCars;
    public Text countDownText;
    bool raceHasStarted;

    void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (raceHasStarted)
        {
            int hasFinished = 0;
            for (int i = 0; i < playerCars.Count; i++)
            {
                if (playerCars[i].hasFinished == true)
                {
                    hasFinished++;
                }
            }
            if (hasFinished == playerCars.Count)
            {
                StartCoroutine(EndOfRace());
            }
        }
    }

    IEnumerator CountdownToStart()
    {
        yield return new WaitForSeconds(0.5f);
        NewCarControll[] carControlls = FindObjectsOfType<NewCarControll>();
        foreach (NewCarControll newCar in carControlls)
        {
            playerCars.Add(newCar);
        }
        yield return new WaitForSeconds(1f);
        for (int i = 3; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        countDownText.text = "GO!";
        for (int i = 0; i < playerCars.Count; i++)
        {
            playerCars[i].CarBRR();
            playerCars[i].handBrakeOn = false;
        }
        yield return new WaitForSeconds(1);
        countDownText.text = null;
        raceHasStarted = true;
    }
    IEnumerator EndOfRace()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(5);
    }
}
