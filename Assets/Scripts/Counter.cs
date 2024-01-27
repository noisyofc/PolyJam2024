using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public float countdownDuration = 60.0f; // Set the initial countdown duration in seconds
    private float currentTime;
    private bool isCountdownRunning = false;

    public TextMeshProUGUI countdownText; // Attach a UI Text component to this variable in the Unity Editor
    public pauseManagerScr pMS;
    void Start()
    {
        pMS = FindObjectOfType<pauseManagerScr>();
        currentTime = countdownDuration;
        UpdateCountdownText();
        StartCountdown();
    }

    void Update()
    {
        if (!pMS.isPaused)
        {
            if (isCountdownRunning)
            {
                if (currentTime > 0)
                {
                    currentTime -= Time.deltaTime;
                    UpdateCountdownText();
                }
                else
                {
                    currentTime = 0;
                    isCountdownRunning = false;
                    Debug.Log("Time's up! Countdown complete.");
                    FindObjectOfType<pauseManagerScr>().Win();
                    // Add any additional actions you want to perform when the countdown reaches zero.
                }
            }
        }
    }

    void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartCountdown()
    {
        isCountdownRunning = true;
    }

    public void StopCountdown()
    {
        isCountdownRunning = false;
    }

    // You can call these methods from other scripts or UI buttons to start or stop the countdown.

    // Example usage:
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         StartCountdown();
    //     }
    // }
}
