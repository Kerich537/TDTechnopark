using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContentController : MonoBehaviour
{
    [SerializeField] private StoreScriptableObject[] _storeScriptableObjects;
    [SerializeField] private GameObject _cellPrefab;

    private void Start()
    {
        CreateCells();
    }

    private void CreateCells()
    {
        foreach (StoreScriptableObject storeScriptableObject in _storeScriptableObjects)
        {
            GameObject newCell = Instantiate(_cellPrefab);
            newCell.transform.parent = transform;
            newCell.GetComponent<StoreCellController>().FillSell(storeScriptableObject);
        }
    }
}
