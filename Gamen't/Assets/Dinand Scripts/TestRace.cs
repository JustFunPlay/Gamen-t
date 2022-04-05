using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestRace : MonoBehaviour
{
    public NewCarControll playerCar;
    public Text countDownText;
    bool raceHasStarted;
    private void Start()
    {
        StartCoroutine(Go());
    }
    IEnumerator Go()
    {
        yield return new WaitForSeconds(0.5f);
        playerCar = FindObjectOfType<NewCarControll>();
        yield return new WaitForSeconds(1f);
        for (int i = 3; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        countDownText.text = "GO!";
        playerCar.CarBRR();
        playerCar.handBrakeOn = false;
        yield return new WaitForSeconds(1);
        countDownText.text = null;
        raceHasStarted = true;
    }
    void Update()
    {
        if (raceHasStarted)
        {
            if (playerCar.hasFinished)
            {
                UpdateTrackInformation.isTested = true;
                SceneManager.LoadScene(4);
            }
        }
    }
}
