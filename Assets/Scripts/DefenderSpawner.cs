using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;
    private void OnMouseDown()
    {
        Debug.Log("Mouse was clicked");
        SpawnDefender(GetSquareClicked());
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        return worldPosition;
    }

    private void SpawnDefender(Vector2 worldPosition)
    {
        var mouseClickPosition = GetSquareClicked();
        GameObject newDefender = Instantiate(defender, worldPosition, transform.rotation) as GameObject;
    }
}
