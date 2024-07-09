using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInput : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    
    [HideInInspector]
    public InteractableObject hoveringOverObject;


    void Update()
    {
        CheckInteractObject();

        if (Input.GetMouseButtonDown(0))
        {
            if (hoveringOverObject != null)
            {
                hoveringOverObject.Interact();
            }
        }
    }

    private void CheckInteractObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Create a ray from the camera to the mouse position
        RaycastHit hit; // Create a RaycastHit object to store the information of the object that the ray hits

        if (Physics.Raycast(ray, out hit)) // If the ray hits something, verify if its an InteractableObject
        {
            InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
            if (interactableObject != null)
            {
                hoveringOverObject = interactableObject;
                textOnScreen.text  = hoveringOverObject.objectName;
            }
            else
            {
                hoveringOverObject = null;
                textOnScreen.text = "";
            }
        }
    }
}
