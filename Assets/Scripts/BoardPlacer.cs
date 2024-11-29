using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class BoardPlacer : MonoBehaviour
{
    public GameObject prefab;                     // Prefab to place
    private ARRaycastManager acm;                  // Reference to AR Raycast Manager
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();  // Raycast results
    private bool objectPlaced = false;             // Flag to ensure single placement

    // Store the instantiated object for AgentManager reference
    public GameObject placedObject;

    void Start()
    {
        acm = GetComponent<ARRaycastManager>();    // Initialize AR Raycast Manager
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

    public void ChangePrefab(GameObject newPrefab)
    {
        prefab = newPrefab;
    }

    void Update()
    {
        // Check if the object has already been placed
        if (objectPlaced || !TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (Input.GetTouch(0).phase == TouchPhase.Began && acm.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;            // Get hit position and rotation

            // Place the object, store reference, and set flag to prevent additional placements
            placedObject = Instantiate(prefab, hitPose.position, hitPose.rotation);
            objectPlaced = true;
        }
    }
}