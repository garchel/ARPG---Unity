using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{

    [HideInInspector]
    public Vector3 mouseInputPosition;


    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Create a ray from the camera to the mouse position
        RaycastHit hit; // Create a RaycastHit object to store the information of the object that the ray hits

        if (Physics.Raycast(ray, out hit, float.MaxValue)) // If the ray hits an object
        {
            mouseInputPosition = hit.point; // Set the mouseInputPosition to the point where the ray hits the object
        }
    }
}
