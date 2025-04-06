using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseController : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    [SerializeField] private GameObject _gameUI;
    [SerializeField] private GameObject _restartUI;
    [SerializeField] private GameObject _loseText;
    [SerializeField] private GameObject _winText;

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _gameUI.SetActive(false);
            _restartUI.SetActive(true);
            _loseText.SetActive(true);
            _winText.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        CheckHealth();
    }
}
