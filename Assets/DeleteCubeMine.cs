using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteCubeMine : MonoBehaviour
{
    public BoardManager boardManager; // Reference to the Board script

    void Start()
    {
        boardManager = FindObjectOfType<BoardManager>(); // Automatically find the Board script
    }

    void OnMouseDown()
    {
        // Notify the board manager that a mine was hit
        if (boardManager != null)
        {
            boardManager.MineHit();
        }

        Destroy(gameObject); // Optionally destroy the mine
    }
}
