using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BoardManager : MonoBehaviourPunCallbacks
{
    public int totalBoxes = 22; // Total number of boxes to clear
    private int clearedBoxes = 0; // Count of cleared boxes
    private bool mineHit = false; // Track if a mine was hit
    public Counter singlePlayerTimer; // Reference to the Counter script
    public PhotonView multiPlayerTimer; 
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
        if (PhotonNetwork.InRoom)
        {
            multiPlayerTimer.RPC("StopTimer", RpcTarget.All);
        }
        else
        {
            singlePlayerTimer.StopTimer();
        }

        // Assign Result if win or not
        if(mineHit)
        {
            Result = false;
        }
        else
        {
            Result = true;
        }

        // Multiplayer
        if (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //Single Player
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
