using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] string postMessage;
    public string objectName;

    private void Awake()
    {
        objectName = gameObject.name;
    }

    public void Interact()
    {
        Debug.Log(gameObject.name + ": " + postMessage);
    }
}