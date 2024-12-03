using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiplayerMainMenu : MonoBehaviour
{
    [SerializeField] Button multiPlayButton;
    [SerializeField] TextMeshProUGUI multiPlayButtonText;

    void Start()
    {
        multiPlayButton.interactable = false;
        multiPlayButtonText.text = "Waiting for other player";
    }
    public void playMultiPlayerGame()
    {
        //Multiplayer
        if (PhotonNetwork.InRoom)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }

    void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            if (!PhotonNetwork.IsMasterClient) // If Player 2
            {
                multiPlayButton.interactable = false;
                multiPlayButtonText.text = "Waiting for host to start";
            }
            else if (PhotonNetwork.CurrentRoom.PlayerCount != 2) // If Room contains < 2 players
            {
                multiPlayButton.interactable = false;
                multiPlayButtonText.text = "Waiting for other player";
            }
            else // If both players connected and is Player 1
            {
                multiPlayButton.interactable = true;
                multiPlayButtonText.text = "PLAY";
            }
        }
    }
}
