using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text finalTimeText; // UI element to display the time

    void Start()
    {
        float elapsedTime = Counter.finalTime; // Get the elapsed time
        DisplayTime(elapsedTime); // Format and display it
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        finalTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}