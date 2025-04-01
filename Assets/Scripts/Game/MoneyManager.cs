using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;

    [SerializeField] private float _startMoney;
    private float _money;
    public float GetMoney()
    {
        return _money;
    }
    public void AddMoney(float moneyToAdd)
    {
        _money += moneyToAdd;
        _moneyText.text = _money + "";
    }

    private void Awake()
    {
        _money = _startMoney;
        AddMoney(0);
    }
}
