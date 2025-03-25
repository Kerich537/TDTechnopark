using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject _deathFxPrefab;

    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _acceleration = 2.0f;

    [SerializeField] private float _health = 100f;
    [SerializeField] private float _damage = 10f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Transform destination = FindObjectOfType<PlayerBaseController>().transform;

        agent.speed = _speed;
        agent.acceleration = _acceleration;
        agent.destination = destination.position;

        _health = 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out PlayerBaseController playerBaseController))
        {
            playerBaseController.Health -= _damage;
            Destroy(gameObject);
        }
    }
}
