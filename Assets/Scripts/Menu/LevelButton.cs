using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _sceneLevelIndex;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(_sceneLevelIndex);
    }
}
