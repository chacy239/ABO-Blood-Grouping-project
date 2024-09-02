using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialText; 
    private string[] tutorialMessages; 
    private int currentCheckpointIndex = 0; 

    void Start()
    {
        tutorialMessages = new string[]
        {
            "Test message1",
            "Test message2",
            "Test message3",
            "Test message4",
            "Test message5"
        };

        tutorialText.SetActive(false); 
    }

    public void UpdateCheckpoint(int checkpointIndex)
    {
        if (checkpointIndex < tutorialMessages.Length)
        {
            currentCheckpointIndex = checkpointIndex;
        }
    }

    public void ShowTutorial()
    {
        tutorialText.SetActive(!tutorialText.activeSelf);

        if (tutorialText.activeSelf)
        {
            tutorialText.GetComponent<Text>().text = tutorialMessages[currentCheckpointIndex];
        }
    }
}