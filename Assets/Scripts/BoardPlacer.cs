using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BoardPlacer : MonoBehaviour
{

    ARAnchorManager anchorManager;
    [SerializeField] private GameObject prefabToAnchor;
    [SerializeField] private float forwardOffset = 2f;
    private bool isPlaced;

    // Start is called before the first frame update
    void Start()
    {
        anchorManager = GetComponent<ARAnchorManager>();
        isPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began && isPlaced == false)
        {
            Vector3 spawnPos = 
                Camera.main.ScreenPointToRay(Input.GetTouch(0).position).GetPoint(forwardOffset);

            AnchorObject(spawnPos);
            isPlaced = true;
        }
    }

    public void AnchorObject(Vector3 spawnPos)
    {
        GameObject newAnchor = new GameObject("NewAnchor");
        newAnchor.transform.parent = null;
        newAnchor.transform.position = spawnPos;
        newAnchor.AddComponent<ARAnchor>();

        GameObject obj = Instantiate(prefabToAnchor, newAnchor.transform);
        obj.transform.localPosition = Vector3.zero;
    }
}
