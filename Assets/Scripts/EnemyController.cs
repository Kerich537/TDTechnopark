using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject deathFxPrefab;

    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float acceleration = 2.0f;

    [SerializeField] private int health = 100;
    [SerializeField] private int price = 20;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Transform destination = FindObjectOfType<PlayerBaseController>().transform;

        agent.speed = speed;
        agent.acceleration = acceleration;
        agent.destination = destination.position;

        health = 100;
    }
}
