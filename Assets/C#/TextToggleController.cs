using UnityEngine;
using UnityEngine.UI;

public class TextToggleController : MonoBehaviour
{
    public GameObject tipText; // Text element used to display tip text
    public GameObject[] stepArrows; // Arrows corresponding to each step

    private bool isTutorialActive = false; // Used to track whether tutorial mode is started

    //Method: Toggle display of prompt text and arrows for the current step
    public void ToggleTutorial(int step)
    {
        isTutorialActive = !isTutorialActive; // Switch state each time the button is pressed

        if (isTutorialActive)
        {
            ShowTipAndArrow(step); // Display the corresponding arrow and prompt text
        }
        else
        {
            HideTipAndArrow(); // Hide all arrows and text
        }
    }

    private void ShowTipAndArrow(int step)
    {
        tipText.gameObject.SetActive(true); // Display tip text
        if (step >= 0 && step < stepArrows.Length)
        {
            stepArrows[step].SetActive(true); // Display the corresponding arrows
        }
    }

    private void HideTipAndArrow()
    {
        tipText.gameObject.SetActive(false); //Hide tip text
        foreach (GameObject arrow in stepArrows)
        {
            arrow.SetActive(false); // Hide all arrows
        }
    }
}