using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [HideInInspector] public ItemGrid selectedItemGrid;
    Vector2Int positionOnGrid;
    InventoryItem selectedItem;
    InventoryItem overlapItem;
    RectTransform selectedItemRectTransform;
    [SerializeField] List<ItemData> itemDatas;
    [SerializeField] GameObject inventoryItemPrefab;
    [SerializeField] Transform targetCanvas;



    private void Update()
    {
        ProcessMouseInput();
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddRandomItemToInventory();
        }
    }

    private void AddRandomItemToInventory()
    {
        GameObject newItemGO = Instantiate(inventoryItemPrefab, targetCanvas);
        
        InventoryItem newInventoryItem = newItemGO.GetComponent<InventoryItem>();
        selectedItem = newInventoryItem;

        RectTransform newItemRectTransform = newItemGO.GetComponent<RectTransform>();
        newItemRectTransform.SetParent(targetCanvas);
        selectedItemRectTransform = newItemRectTransform;
    
        int selectedItemID = UnityEngine.Random.Range(0, itemDatas.Count);
        newInventoryItem.Set(itemDatas[selectedItemID]);
    
    }

    private void ProcessMouseInput()
    {
        if (selectedItem != null)
        {
            selectedItemRectTransform.position = Input.mousePosition;
        }

        if (selectedItemGrid == null) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            positionOnGrid = GetTileGridPosition();
            if (selectedItem == null)
            {
                selectedItem = selectedItemGrid.PickUpItem(positionOnGrid);
                if (selectedItem != null)
                {
                    selectedItemRectTransform = selectedItem.GetComponent<RectTransform>();
                }
            }
            else
            {
                PlaceItemInput();
            }
        }
    }

    Vector2Int GetTileGridPosition()
    {
        Vector2 position = Input.mousePosition;
        if (selectedItem != null)
        {
            position.x -= (selectedItem.itemData.sizeWidth - 1) * ItemGrid.TileSizeWidth / 2;
            position.y += (selectedItem.itemData.sizeHeight - 1) * ItemGrid.TileSizeHeight / 2;
        }

        return selectedItemGrid.GetTileGridPosition(position);
    }

    private void PlaceItemInput()
    {
        if (selectedItemGrid.BoundryCheck(positionOnGrid.x, positionOnGrid.y, selectedItem.itemData.sizeWidth, selectedItem.itemData.sizeHeight) == false)
        {
            return;
        }

        if (selectedItemGrid.CheckOverlap(positionOnGrid.x, positionOnGrid.y, selectedItem.itemData.sizeWidth, selectedItem.itemData.sizeHeight, ref overlapItem) == false)
        {
            overlapItem = null;
            return;
        }
        if (overlapItem != null)
        {
            selectedItemGrid.ClearGridFromItem(overlapItem);
        }


        selectedItemGrid.PlaceItem(selectedItem, positionOnGrid.x, positionOnGrid.y);
        selectedItem = null;
        selectedItemRectTransform = null;

        if (overlapItem != null) // Se há um item sobreposto ao item que está sendo movido substitua o item que está sendo movido pelo item sobreposto
        {
            selectedItem = overlapItem;
            selectedItemRectTransform = selectedItem.GetComponent<RectTransform>();
            overlapItem = null;
        }
    }
}
