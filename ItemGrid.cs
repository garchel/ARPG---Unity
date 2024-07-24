using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemGrid : MonoBehaviour
{
    InventoryItem[,] inventoryItemGrid;
    public const float TileSizeWidth = 32f;
    public const float TileSizeHeight = 32f;
    [SerializeField] int gridSizeWidth;
    [SerializeField] int gridSizeHeight;

    RectTransform rectTransform;

    Vector2 mousePositionOnTheGrid;
    Vector2Int tileGridPosition = new Vector2Int();

    [SerializeField] GameObject inventoryItemPrefab;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

    }

    private void Start()
    {
        Init(gridSizeWidth, gridSizeHeight);

    }

    private void Init(int width, int height)
    {
        inventoryItemGrid = new InventoryItem[width, height];
        Vector2 size = new Vector2();
        size.x = TileSizeWidth * width;
        size.y = TileSizeHeight * height;
        rectTransform.sizeDelta = size;

    }

    public void PlaceItem(InventoryItem itemToPlace, int x, int y)
    {
        RectTransform itemRectTransform = itemToPlace.GetComponent<RectTransform>();
        itemRectTransform.SetParent(transform);

        for (int ix = 0; ix < itemToPlace.itemData.sizeWidth; ix++) // Percorre a largura e comprimento do item preenchendo o grid com o item ("sua presença")
        {
            for (int iy = 0; iy < itemToPlace.itemData.sizeHeight; iy++)
            {
                inventoryItemGrid[x + ix, y + iy] = itemToPlace;
            }
        }

        itemToPlace.positionOnGridX = x;
        itemToPlace.positionOnGridY = y;

        itemRectTransform.localPosition = CalculatePositionOfObjectOnGrid(itemToPlace, x, y);
    }

    public Vector2 CalculatePositionOfObjectOnGrid(InventoryItem item, int x, int y)
    {
        Vector2 positionOnGrid = new Vector2();

        positionOnGrid.x = TileSizeWidth * x + TileSizeWidth *  item.itemData.sizeWidth / 2;
        positionOnGrid.y = -(TileSizeHeight * y + TileSizeHeight * item.itemData.sizeHeight / 2);
        return positionOnGrid;
    }

    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        mousePositionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        mousePositionOnTheGrid.y = rectTransform.position.y - mousePosition.y;

        
        tileGridPosition.x = (int)(mousePositionOnTheGrid.x / TileSizeWidth);
        tileGridPosition.y = (int)(mousePositionOnTheGrid.y / TileSizeHeight);

        return tileGridPosition;
    }

    public InventoryItem PickUpItem(Vector2Int tilePositionOnGrid)
    {
        InventoryItem pickedItem = inventoryItemGrid[tilePositionOnGrid.x, tilePositionOnGrid.y];

        if (pickedItem == null) { return null; }

        ClearGridFromItem(pickedItem);

        return pickedItem;
    }

    public void ClearGridFromItem(InventoryItem pickedItem)
    {
        for (int ix = 0; ix < pickedItem.itemData.sizeWidth; ix++)
        {
            for (int iy = 0; iy < pickedItem.itemData.sizeHeight; iy++)
            {
                inventoryItemGrid[pickedItem.positionOnGridX + ix, pickedItem.positionOnGridY + iy] = null;
            }
        }
    }

    bool PositionCheck(int x, int y)
    {
        if (x < 0 || y < 0)
        {
            return false;
        }
 
        if (x >= gridSizeWidth || y >= gridSizeHeight)
        {
            return false;
        }

        return true;
    }

    public bool BoundryCheck(int posX, int posY, int width, int height)
    {
        if (PositionCheck(posX, posY) == false) {return false;}

        posX += width - 1;
        posY += height - 1;

        if (PositionCheck(posX, posY) == false) {return false;}

        return true;
        
    }

    public bool CheckOverlap(int posX, int posY, int sizeWidth, int sizeHeight, ref InventoryItem overlapItem)
    {
        for (int x = 0; x < sizeWidth; x++)
        {
            for (int y = 0; y < sizeHeight; y++)
            {
                if (inventoryItemGrid[posX + x, posY + y] != null)
                {
                    if (overlapItem == null)
                    {
                        overlapItem = inventoryItemGrid[posX + x, posY + y];
                    }
                    else
                    {
                        if (overlapItem != inventoryItemGrid[posX + x, posY + y])
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }

    public InventoryItem GetItem(int x, int y)
    {
        return inventoryItemGrid[x, y];
    }

    public Vector2Int? FindSpaceForObject(InventoryItem itemToInsert)
    {
        int height = gridSizeHeight - itemToInsert.itemData.sizeHeight + 1;
        int width = gridSizeWidth - itemToInsert.itemData.sizeWidth + 1;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (CheckAvailableSpace(x, y, itemToInsert.itemData.sizeWidth, itemToInsert.itemData.sizeHeight))
                {
                    return new Vector2Int(x, y);
                }
            }
        }

        return null;
    }

    private bool CheckAvailableSpace(int posX, int posY, int sizeWidth, int sizeHeight)
    {
        for (int x = 0; x < sizeWidth; x++)
        {
            for (int y = 0; y < sizeHeight; y++)
            {
                if (inventoryItemGrid[posX + x, posY + y] != null)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
