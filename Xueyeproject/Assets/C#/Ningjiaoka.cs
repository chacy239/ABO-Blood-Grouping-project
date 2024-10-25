using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ningjiaoka : MonoBehaviour
{

    private void OnEnable()
    {
        int index = Random.Range(0, 8);
        for (int i = 0; i < 8; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
        gameObject.transform.GetChild(index).gameObject.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
