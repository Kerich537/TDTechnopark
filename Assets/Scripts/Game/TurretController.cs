using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _towerTransform;
    [SerializeField] private Transform _muzzleFlash;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _shotDistance;
    [SerializeField] private float _reloadTime;

    [SerializeField] private LayerMask _enemyLayerMask;
    private GameObject _target;

    private void Start()
    {
        StartCoroutine("Shoot");
    }

    private void Update()
    {
        if (_target == null)
            FindTarget();
        else
            CheckTargetIsInRange();

        AimToTarget();
    }

    private void FindTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _shotDistance, _enemyLayerMask);
        if (colliders.Length > 0)
        {
            _target = colliders[0].gameObject;
        }
    }

    private void CheckTargetIsInRange()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);

        if (distanceToTarget > _shotDistance)
            _target = null;
    }

    private void AimToTarget()
    {
        if (_target == null)
            return;

        Vector3 enemyDirection = (new Vector3(_target.GetComponent<EnemyController>().GetPointToShot().x - transform.position.x,
            0, _target.GetComponent<EnemyController>().GetPointToShot().z - transform.position.z)).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(enemyDirection);
        _towerTransform.rotation = Quaternion.Slerp(_towerTransform.transform.rotation, lookRotation, Time.deltaTime * _rotateSpeed);
    }

    private IEnumerator Shoot()
    {
        if (_target != null)
        {
            Instantiate(_bulletPrefab, _muzzleFlash.position, _muzzleFlash.rotation);
        }

        yield return new WaitForSeconds(_reloadTime);
        StartCoroutine("Shoot");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _shotDistance);
    }
}
