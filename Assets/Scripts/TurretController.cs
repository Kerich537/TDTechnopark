using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _towerTransform;
    [SerializeField] private Transform _muzzleFlash;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _shotDistance;
    [SerializeField] private float _reloadTime;
    private GameObject _chosenEnemy;

    private CapsuleCollider _collider;
    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine("Shoot");
        _collider = GetComponent<CapsuleCollider>();
        _collider.radius = _shotDistance;
    }

    private void Update()
    {
        AimToEnemy();
        CheckFirstEnemyAtList();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyController enemyController))
        {
            enemies.Add(enemyController.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyController enemyController))
        {
            enemies.Remove(enemyController.gameObject);
        }
    }

    public void CheckFirstEnemyAtList()
    {
        if (enemies.Count > 0 && enemies[0].activeInHierarchy == false)
        {
            GameObject diedEnemy = enemies[0];
            enemies.RemoveAt(0);
            Destroy(diedEnemy);
        }
    }

    private void AimToEnemy()
    {
        if (enemies.Count == 0)
            return;

        _chosenEnemy = enemies[0];
        Vector3 enemyDirection = (_chosenEnemy.GetComponent<EnemyController>().GetPointToShot() - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(enemyDirection);
        _towerTransform.rotation = Quaternion.Slerp(_towerTransform.transform.rotation, lookRotation, Time.deltaTime * _rotateSpeed);
    }

    private IEnumerator Shoot()
    {
        if (_chosenEnemy != null)
        {
            Instantiate(_bulletPrefab, _muzzleFlash.position, _muzzleFlash.rotation);
        }

        yield return new WaitForSeconds(_reloadTime);
        StartCoroutine("Shoot");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _shotDistance);
    }
}
