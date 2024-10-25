using UnityEngine;
using UnityEngine.UI;

public class TextToggleController1 : MonoBehaviour
{
    public GameObject tipText;  

    public void OnButtonClick()
    {
        tipText.SetActive(!tipText.activeSelf);
    }
}