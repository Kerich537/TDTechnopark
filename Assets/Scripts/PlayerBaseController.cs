using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseController : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    public float Health { get { return _currentHealth; } set {  _currentHealth = value; CheckHealth(); } } 

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            // Game over and restart
        }
    }
}
