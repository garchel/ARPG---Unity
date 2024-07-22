using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteractableObject : MonoBehaviour
{
    [SerializeField] int coinCount;

    private void Start()
    {
        GetComponent<InteractableObject>().interact += PickUp;
    }

    public void PickUp(Inventory inventory)
    {
        inventory.AddCurrency(coinCount);
        Debug.Log("Picked up object");
        Destroy(gameObject);
    }
}
