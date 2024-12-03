using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class Counter : MonoBehaviourPunCallbacks
{
    public float timeRemaining = 0;  // Stores elapsed time
    public bool timeIsRunning = false;  // Timer starts stopped
    public TMP_Text timeText;        // Reference to the TMP_Text for displaying the timer
    public static float finalTime;   // Static variable to hold the final time for the next scene

    void Start()
    {
        timeIsRunning = false;
    }

    void Update()
    {
        if (timeIsRunning)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining += Time.deltaTime;
                if (PhotonNetwork.InRoom)
                {
                    this.photonView.RPC("DisplayTime", RpcTarget.All, timeRemaining);
                }
                else
                {
                    DisplayTime(timeRemaining);
                }
                
            }
        }
    }

    [PunRPC]
    public void StartTimer()
    {
        timeIsRunning = true; // Start the timer
        Debug.Log("Timer started!");
    }

    [PunRPC]
    public void StopTimer()
    {
        timeIsRunning = false; // Stop the timer
        finalTime = timeRemaining; // Save the final time
        Debug.Log("Timer stopped! Final time: " + finalTime);
    }

    [PunRPC]
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); // Get minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Get seconds
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Format and display
    }
}
