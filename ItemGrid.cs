using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemGrid : MonoBehaviour
{
    const float TileSizeWidth = 32f;
    const float TileSizeHeight = 32f;

    RectTransform rectTransform;

    Vector2 mousePositionOnTheGrid;
    Vector2Int tileGridPosition = new Vector2Int();

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        mousePositionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        mousePositionOnTheGrid.y = rectTransform.position.y - mousePosition.y;

        
        tileGridPosition.x = (int)(mousePositionOnTheGrid.x / TileSizeWidth);
        tileGridPosition.y = (int)(mousePositionOnTheGrid.y / TileSizeHeight);

        return tileGridPosition;
    }
}
