using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public static UserDataManager instance;

    public string fullName;
    public string dateOfBirth;
    public string labNumber;
    private int cycleCount = 0;

    void Awake()
    {
        // Ensure that this object will not be destroyed when switching scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);  // If an instance already exists, destroy the extra instance
        }
    }


    //Save user information
    public void SaveUserData(string name, string dob, string labNum, int count)
    {
        fullName = name;
        dateOfBirth = dob;
        labNumber = labNum;
        cycleCount = count;
    }

    // Get user information
    public string GetFullName() { return fullName; }
    public string GetDateOfBirth() { return dateOfBirth; }
    public string GetLabNumber() { return labNumber; }
    public int GetCycleCount() { return cycleCount; }
}