using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _pointToShotTransform;

    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _acceleration = 2.0f;

    [SerializeField] private float _maxHealth;
    private float _health;

    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _enemyPrice;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Transform destination = FindObjectOfType<PlayerBaseController>().transform;

        agent.speed = _speed;
        agent.acceleration = _acceleration;
        agent.destination = destination.position;

        _health = _maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (other.transform.parent.TryGetComponent(out PlayerBaseController playerBaseController))
            {
                playerBaseController.TakeDamage(_damage);
            }
        }
    }

    private void CheckHealth()
    {
        if (_health <= 0)
        {
            FindObjectOfType<MoneyManager>().AddMoney(_enemyPrice);
            _health = 0;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        CheckHealth();
    }

    public Vector3 GetPointToShot()
    {
        return _pointToShotTransform.position;
    }
}
