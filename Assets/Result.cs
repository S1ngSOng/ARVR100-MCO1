using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public TMP_Text game_result; // UI element to display the time

    void Start()
    {
        bool result = BoardManager.Result; // Get the elapsed time
        DisplayResult(result); // Format and display it
    }

    void DisplayResult(bool result)
    {
        if(result)
        {
            game_result.text = "You Win!";
        }
        else
        {
            game_result.text = "You Lose!";
        }
        
    }
}