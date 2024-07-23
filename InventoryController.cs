using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector] public ItemGrid selectedItemGrid;
    Vector2Int positionOnGrid;
    InventoryItem selectedItem;
    RectTransform selectedItemRectTransform;

    private void Update()
    {
        if (selectedItemRectTransform != null)
        {
            selectedItemRectTransform.position = Input.mousePosition;
        }
        
        if (selectedItemGrid == null) {return;}

        if (Input.GetMouseButtonDown(0))
        {
            positionOnGrid = selectedItemGrid.GetTileGridPosition(Input.mousePosition);
            if (selectedItem == null)
            {
                selectedItem = selectedItemGrid.PickUpItem(positionOnGrid);
                selectedItemRectTransform = selectedItem.GetComponent<RectTransform>();
            }
            else
            {
                selectedItemGrid.PlaceItem(selectedItem, positionOnGrid.x, positionOnGrid.y);
                selectedItem = null;
                selectedItemRectTransform = null;
            }
        }
    }
}
