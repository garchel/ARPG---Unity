using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI currencyText;
    [SerializeField] Inventory playerInventory;
    int currency = -1;

    void Update()
    {
        if (currency != playerInventory.currency)
        {
            currencyText.text = playerInventory.currency.ToString();
            currency = playerInventory.currency;

        }
    }

}
