using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.XR.ARFoundation;

public class GameOver : MonoBehaviourPunCallbacks
{
    public AudioClip winGameAudio;

    AudioSource audio;

    void Start()
    {
        bool result = BoardManager.Result;
        audio = GetComponent<AudioSource>();

        if (result)
        {
            audio.PlayOneShot(winGameAudio, 0.8f);
        }
    }

    // Method to restart or play again
    public void PlayGame()
    {
        if (PhotonNetwork.InRoom){PhotonNetwork.LeaveRoom();}
        SceneManager.LoadScene("Opening");

    }
}
