using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    [SerializeField] TextMeshProUGUI myText;
    int playerCount;

    void Start()
    {
        ConnectToPhoton();

        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to Photon...");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room available. Creating a new room...");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room!");
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        myText.text = "Players in Room: " + playerCount;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        myText.text = "Players in Room: " + playerCount;
    }

    public void LeaveRoom()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        myText.text = "Players in Room: " + playerCount;
    }

    

    /*    // Update is called once per frame
        void Update()
        {

        }*/
}
