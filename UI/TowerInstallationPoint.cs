using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstallationPoint : MonoBehaviour
{
    public int TotalTowerCost { get; private set; }
    public int UpgradeCost { get; private set; }
    public bool IsPointEmpty { get; private set; }
    private ShopUI _shopUI;
    private UpgradeTowerMenu _upgradeUI;
    private GameObject _currentTower;

    private void Start()
    {
        IsPointEmpty = true;
    }

    public void BuildTower(GameObject tower, int money)
    {
        _shopUI.GetComponent<GameData>().BuyTower(money);
        UpgradeCost = money;
        _currentTower = tower;
        IsPointEmpty = false;
        TotalTowerCost += money;
    }

    public void UpgradeTower(int money)
    {
        UpgradeCost += 5;
        TotalTowerCost += money;
    }

    public void SellTower()
    {
        _shopUI.GetComponent<GameData>().SellTower(TotalTowerCost);
        Destroy(_currentTower.gameObject);
        _currentTower = null;
        IsPointEmpty = true;
    }

    private void OnMouseUpAsButton()
    {
        if (_shopUI == null || _upgradeUI == null)
        {
            _shopUI = FindObjectOfType<ShopUI>();
            _upgradeUI = FindObjectOfType<UpgradeTowerMenu>();
        }

        if (IsPointEmpty)
        {
            if (_upgradeUI.gameObject.activeInHierarchy)
                _upgradeUI.CloseUpgradeMenu();
            _shopUI.OpenShopUI(gameObject.transform);
        }
        else
        {
            if (_shopUI.gameObject.activeInHierarchy)
                _shopUI.CloseShopUI();
            _upgradeUI.OpenUpgradeMenu(_currentTower.GetComponentInChildren<Tower>(), this);
        }
    }
}
