using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _currentLevel;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(_currentLevel);
    }
}
