using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using CandyCoded.HapticFeedback;

public class DeleteCubeMine : MonoBehaviourPunCallbacks
{
    public BoardManager boardManager; // Reference to the Board script
    public AudioClip sweepEffect;
    public AudioClip explosionEffect;

    AudioSource audio;

    void Start()
    {
        boardManager = FindFirstObjectByType<BoardManager>();
        audio = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (PhotonNetwork.InRoom)
        {
            this.photonView.RPC("sweepBox", RpcTarget.All);
        }
        else
        {
            sweepBox();
        }

        // Notify the board manager that a mine was hit
        if (boardManager != null)
        {
            if (PhotonNetwork.InRoom)
            {
                this.photonView.RPC("callMineHit", RpcTarget.All);
            }
            else
            {
                callMineHit();
            }
        }


    }

    [PunRPC]
    void sweepBox()
    {
        HapticFeedback.MediumFeedback();
        audio.PlayOneShot(explosionEffect, 1f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    [PunRPC]
    void callMineHit()
    {
        boardManager.MineHit();
    }
}
