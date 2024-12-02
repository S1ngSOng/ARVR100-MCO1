using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class DeleteCube : MonoBehaviourPunCallbacks
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