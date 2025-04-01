using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private bool _haveSplash;
    [SerializeField] private float _splashRadius;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyController enemyController) && !_haveSplash)
        {
            Debug.Log("A");
            enemyController.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (_haveSplash && !TryGetComponent(out TurretController turretController))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _splashRadius);

            foreach (Collider collider in hitColliders)
            {
                if (collider.TryGetComponent(out EnemyController enemyController1))
                {
                    enemyController1.TakeDamage(_damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
