using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _maxTime = 5f;
    [SerializeField] private float _standartTime = 1f;
    [SerializeField] private float _minTime = 0.1f;

    [SerializeField] private float _step;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Time.timeScale += _step;
            if (Time.timeScale > _maxTime)
                Time.timeScale = _maxTime;
            Debug.Log(Time.timeScale + "x");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Time.timeScale -= _step;
            if (Time.timeScale < _minTime)
                Time.timeScale = _minTime;
            Debug.Log(Time.timeScale + "x");
        }
    }
}
