using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class DeleteCubeMine : MonoBehaviourPunCallbacks
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

        if (PhotonNetwork.InRoom)
        {
            this.photonView.RPC("sweepBox", RpcTarget.All);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    [PunRPC]
    void sweepBox()
    {
        Destroy(gameObject);
    }
}
