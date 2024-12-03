using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class Result : MonoBehaviourPunCallbacks
{
    public TMP_Text game_result;

    void Start()
    {
        bool result = BoardManager.Result;
        if (PhotonNetwork.InRoom)
        {
            this.photonView.RPC("DisplayResult", RpcTarget.All, result);
        }
        else
        {
            DisplayResult(result);
        }
        
    }

    [PunRPC]
    void DisplayResult(bool result)
    {
        if(result)
        {
            game_result.text = "You Win!";
        }
        else
        {
            game_result.text = "You Lose!";
        }
        
    }
}