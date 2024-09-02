using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject openMenuButton;
    public MouseLook1 mouseLookXScript;
    public MouseLook1 mouseLookYScript;
    public RigibodyMove rigibodyMoveScript;

    public void Start()
    {
        menuPanel.SetActive(false);
        openMenuButton.SetActive(true);
        Time.timeScale = 1f;
        mouseLookXScript.enableMouseInput = true; 
        mouseLookYScript.enableMouseInput = true;
        rigibodyMoveScript.enableMovement = true;
    }

    public void GoReturn()
    {

    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        openMenuButton.SetActive(false);
        Time.timeScale = 0f;
        mouseLookXScript.enableMouseInput = false; 
        mouseLookYScript.enableMouseInput = false;
        rigibodyMoveScript.enableMovement = false;
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        openMenuButton.SetActive(true);
        Time.timeScale = 1f;
        mouseLookXScript.enableMouseInput = true; 
        mouseLookYScript.enableMouseInput = true;
        rigibodyMoveScript.enableMovement = true;
    }

}
