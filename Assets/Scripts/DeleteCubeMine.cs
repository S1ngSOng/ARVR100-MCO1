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
        boardManager = FindObjectOfType<BoardManager>();
    }

    void OnMouseDown()
    {
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

    [PunRPC]
    void callMineHit()
    {
        boardManager.MineHit();
    }
}
