using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightTimer : MonoBehaviour
{
    public Text timerText; 
    public float flightDuration = 10f; 
    private float timer;
    private bool isTimerRunning = false;

    public GameObject returnUI;
    public bool IsTimerFinished { get; private set; } = false; // Tambahkan properti publik untuk status timer

    void Start()
    {
        timer = flightDuration;
        isTimerRunning = true;
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                isTimerRunning = false;
                IsTimerFinished = true; // Setel status timer selesai

                if (returnUI != null)
                {
                    returnUI.SetActive(true);
                }

                Debug.Log("Waktu habis! Kembali ke bandara.");
            }

            if (timerText != null)
            {
                timerText.text = FormatTime(timer);
            }
        }
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

