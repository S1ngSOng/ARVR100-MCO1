using UnityEngine;

public class DeleteCube : MonoBehaviour
{
    public BoardManager boardManager; // Reference to the Board script

    void Start()
    {
        boardManager = FindObjectOfType<BoardManager>(); // Automatically find the Board script
    }

    void OnMouseDown()
    {
        // Notify the board manager about the cleared box
        if (boardManager != null)
        {
            boardManager.BoxCleared();
        }

        Destroy(gameObject); // Destroy the box
    }
}