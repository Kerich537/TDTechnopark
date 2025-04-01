using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPlacement : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private int _height;
    [SerializeField] private int _width;
/*
    private int height;
    private int width;
    private void OnDrawGizmos()
    {
        if (height == _height && _width == width)
            return;

        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        height = _height; width = _width;
        PlaceCells();
    }*/

    private void Start()
    {
        PlaceCells();
    }

    private void PlaceCells()
    {
        if (_cellPrefab == null)
            return;

        for (int h = 0; h < _height; h++)
        {
            for (int w = 0; w < _width; w++)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x + w, transform.position.y, transform.position.z + h);
                GameObject newCell = Instantiate(_cellPrefab, spawnPosition, transform.rotation);
                newCell.transform.SetParent(transform, true);
            }
        }
    }
}
