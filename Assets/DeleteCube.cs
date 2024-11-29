using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Optional: Initialization code can go here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: Update code can go here if needed
    }

    // This method is triggered when the object is clicked
    void OnMouseDown()
    {
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
