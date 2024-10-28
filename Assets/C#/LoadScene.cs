using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{


    private void OnEnable()
    {
        
    }

    // Use this for initialization
    void Start()
    {

    }
    public void Aload(string name)
    {
            SceneManager.LoadScene(name);

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

   
}
