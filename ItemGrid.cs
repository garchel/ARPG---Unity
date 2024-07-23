using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemGrid : MonoBehaviour
{
    InventoryItem[,] inventoryItemGrid;
    const float TileSizeWidth = 32f;
    const float TileSizeHeight = 32f;
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
        CreateTestItem(0,0);
        CreateTestItem(1,0);
        CreateTestItem(2,0);
        CreateTestItem(0,1);
        CreateTestItem(0,2);
    }

    private void CreateTestItem(int x, int y)
    {
        GameObject itemTest = Instantiate(inventoryItemPrefab);
        InventoryItem InventoryItemTest = itemTest.GetComponent<InventoryItem>();
        PlaceItem(InventoryItemTest, x, y);
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

        inventoryItemGrid[x, y] = itemToPlace;

        Vector2 positionOnGrid = new Vector2();

        positionOnGrid.x = TileSizeWidth * x + TileSizeWidth / 2;
        positionOnGrid.y = -TileSizeHeight * y - TileSizeHeight / 2;

        itemRectTransform.localPosition = positionOnGrid;
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
        InventoryItem pickedItem = inventoryItemGrid[tilePositionOnGrid.x , tilePositionOnGrid.y];
        inventoryItemGrid[tileGridPosition.x, tileGridPosition.y] = null;

        return pickedItem;
    }
}
