using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserManualController : MonoBehaviour
{
    public GameObject userManualPanel; // GameObject referencing UserManualPanel
    public Button closeButton; // Button that references the close button

    void Start()
    {
        // Display the user manual when entering the scene
        userManualPanel.SetActive(true);

        // Bind the close button click event and close the user manual when pressed
        closeButton.onClick.AddListener(CloseUserManual);
    }

    //Method: Close user manual
    private void CloseUserManual()
    {
        userManualPanel.SetActive(false); // Hide user manual
    }
}