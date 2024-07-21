using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private int startingMoney = 0;

    public int currentMoney { get; private set; }

    private void Awake()
    {
        currentMoney = startingMoney;
    }

    private void OnEnable()
    {
        GameEventsManager.Instance.moneyEvents.onMoneyGained += MoneyGained;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.moneyEvents.onMoneyGained -= MoneyGained;
    }

    private void Start()
    {
        GameEventsManager.Instance.moneyEvents.MoneyChange(currentMoney);
    }

    private void MoneyGained(int gold)
    {
        currentMoney += gold;
        GameEventsManager.Instance.moneyEvents.MoneyChange(currentMoney);
    }
}
