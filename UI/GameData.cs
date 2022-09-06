using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    public int Money { get; private set; }
    public int Score { get; private set; }

    private void Start()
    {
        Money = 20;
        _moneyText.text = Money.ToString();
    }
    public void AddScore() => Score++;
    private void UpdateMoneyText() => _moneyText.text = Money.ToString();
    public void UpgradeTower(int money) => BuyTower(money);
    public void BuyTower(int money)
    {
        Money -= money;
        UpdateMoneyText();
    }

    public void SellTower(int money)
    {
        Money += (int)(money / 1.5f);
        UpdateMoneyText();
    }

    public void SetMoney(int money)
    {
        Money += money;
        UpdateMoneyText();
    }
}