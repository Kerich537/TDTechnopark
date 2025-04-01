using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StoreCellController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEngine.UI.Image _turretImage;
    [SerializeField] private TextMeshProUGUI _turretPriceText;

    private TurretPlacement _turretPlacement;

    private int _turretPrice;
    public GameObject _turretPrefab;

    public void FillSell(StoreScriptableObject storeScriptableObject)
    {
        _turretPrefab = storeScriptableObject.turretPrefab;

        _turretPrice = storeScriptableObject.turretPrice;
        _turretPriceText.text = _turretPrice + "";

        _turretImage.sprite = storeScriptableObject.turretSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _turretPlacement = FindObjectOfType<TurretPlacement>();
        Debug.Log("A " + _turretPrefab);
        _turretPlacement.SelectTurret(_turretPrefab, _turretPrice);
    }
}
