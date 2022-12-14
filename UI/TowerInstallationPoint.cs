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
        tower.GetComponentInChildren<UI_TowerLevelUp>().SetUpgradeMenu(_upgradeUI);
        GameData.BuyTower(money);
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

    public int ShowSellPrice() => (int)(TotalTowerCost / 1.5f);

    public void SellTower()
    {
        GameData.SellTower(TotalTowerCost);
        Destroy(_currentTower.gameObject);
        _currentTower = null;
        IsPointEmpty = true;
    }

    private void OnMouseUpAsButton()
    {
        if (IsPointEmpty)
        {
            if (_shopUI == null)
            {
                _shopUI = ShopUI.Instance;
                _upgradeUI = _shopUI.GetComponent<UpgradeTowerMenu>();
            }

            if (_upgradeUI.gameObject.activeSelf)
                _upgradeUI.CloseUpgradeMenu();
            _shopUI.OpenShopUI(gameObject.transform);
        }
        else
        {
            if (_shopUI.gameObject.activeSelf)
                _shopUI.CloseShopUI();
            _upgradeUI.OpenUpgradeMenu(_currentTower.GetComponentInChildren<Tower>(), this);
        }
    }
}