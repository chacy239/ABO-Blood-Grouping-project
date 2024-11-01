using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeSceneManager : MonoBehaviour
{
    public InputField name_imp;
    public InputField id_imp;
    public GameObject errorObj;

    public GameObject timewatch;

    private void OnEnable()
    {
        if (GetStudentName() == null || GetStudentName() == "")
        {

        }
    }

    // Use this for initialization
    void Start()
    {
        timewatch = GameObject.Find("TimeClaculator");
    }
    public void Aload(string name)
    {
        if (name_imp.text == "" || id_imp.text == "")
        {
            StartCoroutine(ErrorPopUp());
        }
        else
        {
            PlayerPrefs.SetString("Name", name_imp.text);
            PlayerPrefs.SetString("Id", id_imp.text);
            Debug.Log("Name : " + name_imp.text + " : ID : " + id_imp.text);
            timewatch.GetComponent<TimeKeeper>().StartTime();
            SceneManager.LoadScene(name);
        }

    }
    public void AExit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetStudentName()
    {
        return PlayerPrefs.GetString("Name", "");
    }

    private IEnumerator ErrorPopUp()
    {
        errorObj.SetActive(true);
        yield return new WaitForSeconds(1);
        errorObj.SetActive(false);


    }
}
