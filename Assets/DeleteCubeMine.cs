using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteCubeMine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Optional: Initialization code can go here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: Update code can go here if needed
    }

    // This method is triggered when the object is clicked
    void OnMouseDown()
    {
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
        gameOver();

    }
    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene
    }
    // Coroutine to handle the delay before switching scenes

}
