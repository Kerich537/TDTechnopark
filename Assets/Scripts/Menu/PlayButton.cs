using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _levelsMenu;

    public void OnPointerClick(PointerEventData eventData)
    {
        _levelsMenu.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
