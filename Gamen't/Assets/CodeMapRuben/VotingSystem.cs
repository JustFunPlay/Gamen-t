using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VotingSystem : MonoBehaviour
{
    public PlayerInformation votingCounter;

    public Button voteButton;

    // Vote number 0 = Voting Back
    // Vote number 1 = Voting Ready
    public void Start()
    {
        ResetNumber();    
    }
    public void OnPressedBack()
    {
        votingCounter.voteNumber[0]++;
        voteButton.interactable = false;
        CountingVotes(1);
    }
    public void OnPressedReady()
    {
        votingCounter.voteNumber[1]++;
        voteButton.interactable = false;
        CountingVotes(3);
    }
    public void CountingVotes(int SceneNumber)
    {
        if(votingCounter.voteNumber[0] >= votingCounter.playerSelections.Count)
        {
            ResetNumber();
            SceneManager.LoadScene(SceneNumber);
        }
        if(votingCounter.voteNumber[1] >= votingCounter.playerSelections.Count)
        {
            ResetNumber();
            SceneManager.LoadScene(SceneNumber);
        }
        
    }
    public void ResetNumber()
    {
        votingCounter.voteNumber[0] = 0;
        votingCounter.voteNumber[1] = 0;
    }
}
