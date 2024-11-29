using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Method to restart or play again
    public void PlayGame()
    {

            SceneManager.LoadScene("Opening");

    }
}
