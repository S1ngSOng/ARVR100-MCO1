using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class BoardPlacer : MonoBehaviourPunCallbacks
{
    public GameObject prefab;                     
    private ARRaycastManager acm;                 
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();  
    private bool objectPlaced = false;
    public ARPlaneManager planeManager;

    // Reference to the timer
    public Counter singlePlayerTimer;
    public PhotonView multiPlayerTimer;

    private BoardManager boardManager;

    void Start()
    {
        acm = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
        if(PhotonNetwork.IsConnected && !PhotonNetwork.IsMasterClient)
        {
            planeManager.enabled = false;
        }
        

        // Find the Counter script in the scene (ensure it's attached to a GameObject)
        singlePlayerTimer = FindObjectOfType<Counter>();
        if (singlePlayerTimer == null)
        {
            Debug.LogError("Counter script not found in the scene.");
        }

        // Find the Board script in the scene
        boardManager = FindObjectOfType<BoardManager>();
        if (boardManager == null)
        {
            Debug.LogError("Board script not found in the scene.");
        }
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        // Check if the object has already been placed
        if (objectPlaced || !TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (Input.GetTouch(0).phase == TouchPhase.Began && acm.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            // Place the object, store reference, and set flag to prevent additional placements
            if (PhotonNetwork.InRoom && PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate("Board", hitPose.position, hitPose.rotation);
                objectPlaced = true;
            }
            else if (!PhotonNetwork.InRoom)
            {
                Instantiate(prefab, hitPose.position, hitPose.rotation);
                objectPlaced = true;
            }

            // Start the timer
            if(objectPlaced == true)
            {
                if (PhotonNetwork.InRoom)
                {
                    if (multiPlayerTimer != null)
                    {
                        multiPlayerTimer.RPC("StartTimer", RpcTarget.All);
                    }
                }
                else
                {
                    if (singlePlayerTimer != null)
                    {
                        singlePlayerTimer.StartTimer();
                    }
                }
            }

            // Notify the Board script to initialize the game logic
            if (boardManager != null)
            {
                boardManager.enabled = true; 
            }

            Debug.Log("Board placed and timer started!");
        }
    }

}
