using Photon.Pun;
using Photon.Realtime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Mainmenu : MonoBehaviourPunCallbacks
{
    [SerializeField] Button multiPlayButton;
    [SerializeField] TextMeshProUGUI multiPlayButtonText;

    void Start()
    {
        multiPlayButton.interactable = true;
        multiPlayButtonText.text = "PLAY";
    }
    public void playgame()
    {
        //Multiplayer
        if (PhotonNetwork.InRoom)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        // Single Player
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                multiPlayButton.interactable = false;
                multiPlayButtonText.text = "Waiting for host to start";
            }
            else if(PhotonNetwork.CurrentRoom.PlayerCount != 2)
            {
                multiPlayButton.interactable = false;
                multiPlayButtonText.text = "Waiting for other player";
            }
            else
            {
                multiPlayButton.interactable = true;
                multiPlayButtonText.text = "PLAY";
            }
        }
    }
}
