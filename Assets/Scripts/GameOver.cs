using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameOver : MonoBehaviourPunCallbacks
{
    // Method to restart or play again
    public void PlayGame()
    {
        if (PhotonNetwork.InRoom){
            PhotonNetwork.LoadLevel("Opening");
            PhotonNetwork.LeaveRoom();
        }
        else
        {
            SceneManager.LoadScene("Opening");
        }
        
    }
}
