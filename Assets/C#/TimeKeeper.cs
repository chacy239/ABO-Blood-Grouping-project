using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{
    public static TimeKeeper Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

    }

    public Text timerText;  // UI Text to display the stopwatch
    private Stopwatch stopwatch;

    void Start()
    {
        stopwatch = new Stopwatch();
        UpdateTimerText();



    }

    // Start the stopwatch
    public void StartTime()
    {
        if (!stopwatch.IsRunning)
        {
            stopwatch.Reset();
            stopwatch.Start();
        }
    }

    // Stop the stopwatch
    public void StopTime()
    {
        if (stopwatch.IsRunning)
        {
            stopwatch.Stop();
        }
        UpdateTimerText();
    }

    void Update()
    {
        if (stopwatch.IsRunning)
        {
          //  UpdateTimerText();
        }
    }

    // Update the displayed time on the UI Text component
    public string UpdateTimerText()
    {
        return $"{stopwatch.Elapsed.Minutes:D2}:{stopwatch.Elapsed.Seconds:D2}:{stopwatch.Elapsed.Milliseconds / 10:D2}";
    }
}
