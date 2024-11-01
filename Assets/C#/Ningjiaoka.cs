using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ningjiaoka : MonoBehaviour
{

    public string bloodGrp;
    public string fileNumb;
    public string studentAns;
    public Transform bloodGrpImages;


    private void OnEnable()
    {
        bloodGrpImages.gameObject.SetActive(true);

        int index = Random.Range(0, bloodGrpImages.childCount);
        for (int i = 0; i < bloodGrpImages.childCount; i++)
        {
            bloodGrpImages.GetChild(i).gameObject.SetActive(false);
        }
        // TODO :: change child enable as per input 


        bloodGrpImages.GetChild(index).gameObject.SetActive(true);
        bloodGrp = bloodGrpImages.GetChild(index).gameObject.name;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        for (int i = 0; i < transform.childCount; i++)  
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        Debug.Log("<color=Blue>aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa</color>");

        SaveTextExample saveScr = GetComponent<SaveTextExample>();
        fileNumb = saveScr.input1.text;
        studentAns = saveScr.input2.text;
    }
}
