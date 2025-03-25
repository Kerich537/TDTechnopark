using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _timeBetweenWave;
    [SerializeField] private float _timeBetweenSpawnEnemy;
    [SerializeField] private List<float> _enemiesInWave;
    [SerializeField] private int _maxWave;
    private int _currentWave = 0;

    private void Start()
    {
        StartCoroutine("SpawnWave");
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < _enemiesInWave[_currentWave]; i++)
        {
            GameObject newEnemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            newEnemy.transform.SetParent(transform, false);

            yield return new WaitForSeconds(_timeBetweenSpawnEnemy);
        }

        _currentWave++;
        yield return new WaitForSeconds(_timeBetweenWave);
        StartCoroutine("SpawnWave");
    }
}
