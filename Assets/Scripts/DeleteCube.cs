using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using CandyCoded.HapticFeedback;
using System.Collections;

public class DeleteCube : MonoBehaviourPunCallbacks
{
    public BoardManager boardManager; // Reference to the Board script
    public AudioClip sweepEffect;

    AudioSource audio;

    void Start()
    {
        boardManager = FindFirstObjectByType<BoardManager>(); // Automatically find the Board script
        audio = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        // Notify the board manager about the cleared box
        if (boardManager != null)
        {
            if (PhotonNetwork.InRoom)
            {
                this.photonView.RPC("callBoxCleared", RpcTarget.All);
            }
            else
            {
                callBoxCleared();
            }
        }

        if (PhotonNetwork.InRoom)
        {
            this.photonView.RPC("sweepBox", RpcTarget.All);
        }
        else
        {
            sweepBox();
        }
    }

    private void Update()
    {
        if (gameObject.GetComponent<MeshRenderer>().enabled == false && audio.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }

    [PunRPC]
    void sweepBox()
    {
        HapticFeedback.MediumFeedback();
        audio.PlayOneShot(sweepEffect, 0.75f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    [PunRPC]
    void callBoxCleared()
    {
        boardManager.BoxCleared();
    }
}