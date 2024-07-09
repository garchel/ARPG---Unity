using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInput : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    GameObject currentHoveringOverObject;
    
    [HideInInspector]
    public InteractableObject hoveringOverObject;
    Character hoveringOverCharacter;
    [SerializeField] UIPoolBar hpBar;


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
            if (currentHoveringOverObject != hit.transform.gameObject)
            {
                currentHoveringOverObject = hit.transform.gameObject;
                UpdateInteractableObject(hit);
            }
        }
    }

    private void UpdateInteractableObject(RaycastHit hit)
    {
        InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
        if (interactableObject != null)
        {
            hoveringOverObject = interactableObject;
            hoveringOverCharacter = interactableObject.GetComponent<Character>();
            textOnScreen.text = hoveringOverObject.objectName;
        }
        else
        {
            hoveringOverCharacter = null;
            hoveringOverObject = null;
            textOnScreen.text = "";
        }
        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        if (hoveringOverCharacter != null)
        {
            hpBar.Show(hoveringOverCharacter.lifePool);
        }
        else
        {
            hpBar.Clear();
        }
    }
}
