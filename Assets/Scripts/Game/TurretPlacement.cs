using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    private GameObject _selectedTurret;

    private bool _isTurretCreated;

    private GameObject _newTurret;
    private TurretController _turretController;
    private float _turretPrice;

    private GameObject _currentCell;
    private GameObject _currentTurret;

    private MoneyManager _moneyManager;

    private void Start()
    {
        _moneyManager = FindObjectOfType<MoneyManager>();
    }

    private void RespawnTurret()
    {
        Destroy(_newTurret);
        _isTurretCreated = false;
    }

    private void DestroyTurret()
    {
        if (_currentTurret == null)
            return;

        _currentTurret.transform.parent.GetComponent<Cell>().enabled = true;
        Destroy(_currentTurret);
    }

    private void PlaceTurret()
    {
        if (_currentCell == null)
            return;

        if (_moneyManager.GetMoney() < _turretPrice)
            return;
        else
            _moneyManager.AddMoney(-_turretPrice);

        _newTurret.layer = _currentCell.layer;
        _turretController.transform.parent = _currentCell.transform;
        _turretController.enabled = true;
        _turretController.GetComponent<Collider>().isTrigger = false;
        _currentCell.GetComponent<Cell>().enabled = false;

        _isTurretCreated = false;
        _newTurret = null;
        _turretController = null;
        _currentCell = null;

    }

    private void Update()
    {
        MoveTurret();
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTurret();
        }
        if (Input.GetMouseButtonDown(1))
        {
            DestroyTurret();
        }
    }

    private void MoveTurret()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (_selectedTurret != null)
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (!_isTurretCreated)
                {
                    _newTurret = Instantiate(_selectedTurret, hitInfo.point, _selectedTurret.transform.rotation);
                    _turretController = _newTurret.GetComponent<TurretController>();
                    _turretController.GetComponent<Collider>().isTrigger = true;
                    _turretController.enabled = false;
                    _isTurretCreated = true;
                }

                if (hitInfo.collider.TryGetComponent(out Cell cell) && cell.enabled)
                {
                    _newTurret.transform.position = cell.transform.position;
                    _currentCell = cell.gameObject;
                }
                else if (hitInfo.collider.TryGetComponent(out TurretController turretController))
                {
                    _currentTurret = turretController.gameObject;
                }
                else
                {
                    _newTurret.transform.position = hitInfo.point;
                    _currentCell = null;
                    _currentTurret = null;
                }
            }
        }
    }

    public void SelectTurret(GameObject turret, float turretPrice)
    {
        _turretPrice = turretPrice;

        _selectedTurret = turret;
        RespawnTurret();
    }
}
