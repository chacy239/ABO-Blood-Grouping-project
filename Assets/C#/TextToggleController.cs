using UnityEngine;
using UnityEngine.UI;

public class TextToggleController : MonoBehaviour
{
    public GameObject tipText;  

    public void OnButtonClick()
    {
        tipText.SetActive(!tipText.activeSelf);
    }
}