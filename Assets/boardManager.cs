using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{
    public int totalBoxes = 22; // Total number of boxes to clear
    private int clearedBoxes = 0; // Count of cleared boxes
    private bool mineHit = false; // Track if a mine was hit
    public Counter timer; // Reference to the Counter script
    public static bool Result = true;

    void Start()
    {
        clearedBoxes = 0; // Reset cleared boxes at the start
        mineHit = false;  // Reset mine hit status
    }

    public void BoxCleared()
    {
        if (mineHit) return; // If mine was hit, do nothing

        clearedBoxes++; // Increment cleared boxes

        if (clearedBoxes >= totalBoxes)
        {
            EndGame(); // End game when all boxes are cleared
        }
    }

    public void MineHit()
    {
        mineHit = true; // Set mine hit flag
        EndGame(); // End the game immediately
    }

    private void EndGame()
    {
        // Stop the timer
        if (timer != null)
        {
            timer.StopTimer();
        }
        if(mineHit)
        {
            Result = false;
        }
        else
        {
            Result = true;
        }
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
