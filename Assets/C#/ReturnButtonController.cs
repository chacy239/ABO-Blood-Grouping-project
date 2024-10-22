using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReturnButtonController : MonoBehaviour
{
    public MainControl_2 mainControl;  
    public Button returnButton;       

    void Start()
    {
        returnButton.onClick.AddListener(ReturnToPreviousSavePoint);
    }

    public void ReturnToPreviousSavePoint()
    {
        mainControl.ReturnToPreviousSavePoint();
    }
}
