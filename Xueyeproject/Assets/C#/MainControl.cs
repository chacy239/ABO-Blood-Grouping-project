using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour
{
    public GameObject Add_panel, Add_btn;
    void Start()
    {
        Add_btn.GetComponent<Button>().onClick.AddListener(A_add);
    }
    public void A_add()
    {
        Add_panel.SetActive(!Add_panel.activeInHierarchy);
        if (Add_btn.transform.localEulerAngles.z == 0)
        {
            Add_btn.transform.localEulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            Add_btn.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
