using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public int checkpointIndex; 
    public TutorialManager tutorialManager; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(""))
        {
            tutorialManager.UpdateCheckpoint(checkpointIndex);
        }
    }
}
}
