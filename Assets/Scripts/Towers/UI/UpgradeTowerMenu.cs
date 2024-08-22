using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTowerMenu : MonoBehaviour
{
    [SerializeField] private Sprite[] _ranks;
    [SerializeField] private GameObject _upgradeMenu;
    [SerializeField] private Sprite[] _towerSprite;
    [SerializeField] private TextMeshProUGUI _damage, _range, _attackSpeed, _level, _upgrade, _kills;
    [SerializeField] private Image _rankImage;
    [SerializeField] private AudioClip _sellTowerSound, _upgradeTowerSound;
    [SerializeField] private GameObject _installationPointIndicator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Image _towerImage;
    [SerializeField] private GameObject _sellWindow;
    [SerializeField] private TextMeshProUGUI _sellPriceText;
    private WaitForSeconds _time;
    private Coroutine _reloadMenuCoroutine;
    private Tower _tower;
    private TowerInstallationPoint _installationPoint;
    private TowerExperienceSystem _towerExp;
    private int _upgradeCost;

    private void Start()
    {
        _time = new WaitForSeconds(1f);
    }

    public void OpenUpgradeMenu(Tower tower, TowerInstallationPoint instPoint)
    {
        _installationPointIndicator.transform.position = instPoint.gameObject.transform.position;
        _installationPointIndicator.SetActive(true);
        _towerImage.sprite = tower.GetTowerSprite();

        if (_installationPoint != instPoint || _tower != tower)
        {
            _installationPoint = instPoint;
            _tower = tower;
            _towerExp = tower.GetComponent<TowerExperienceSystem>();
        }
        _reloadMenuCoroutine = StartCoroutine(ReloadingWhileMenuIsOpened());
        _upgradeMenu.SetActive(true);
    }
    public void UpgradeTowerLevel()
    {
        if (GameData.Money >= _upgradeCost)
        {
            if (!GameData.IsDisableSounds)
                _audioSource.PlayOneShot(_upgradeTowerSound);
            _installationPoint.UpgradeTower(_upgradeCost);
            GameData.UpgradeTower(_upgradeCost);
            _tower.UpgradeTower();
            RefreshMenu();
        }
    }

    public void ShowSellPriceWindow()
    {
        _sellPriceText.text = _installationPoint.ShowSellPrice().ToString();
        _sellWindow.SetActive(true);
    }
    public void HideSellPriceWindow()
    {
        _sellWindow.SetActive(false);
    }

    public void SellTower()
    {
        HideSellPriceWindow();
        if (!GameData.IsDisableSounds)
            _audioSource.PlayOneShot(_sellTowerSound);
        _installationPoint.SellTower();
        CloseUpgradeMenu();
    }

    public void CloseUpgradeMenu()
    {
        _installationPointIndicator.SetActive(false);
        if (_reloadMenuCoroutine != null)
            StopCoroutine(_reloadMenuCoroutine);
        _upgradeMenu.SetActive(false);
    }

    private IEnumerator ReloadingWhileMenuIsOpened()
    {
        RefreshMenu();
        int kills = _towerExp.KillsCount;
        int level = _towerExp.Level;
        while (true)
        {
            yield return _time;

            if (level != _towerExp.Level)
                RefreshMenu();
            else if (kills != _towerExp.KillsCount)
            {
                kills = _towerExp.KillsCount;
                _kills.text = kills.ToString();
            }
            else TextColor();
        }
    }

    private void RefreshMenu()
    {
        _upgrade.text = (_upgradeCost = _installationPoint.UpgradeCost).ToString();
        _damage.text = _tower.Damage.ToString();
        _range.text = _tower.AttackRange.ToString("#.#");
        _attackSpeed.text = _tower.AttackSpeed.ToString("#.#");
        _kills.text = _towerExp.KillsCount.ToString();
        _level.text = (_towerExp.Level + 1).ToString();
        if (_towerExp.Level < _ranks.Length)
            _rankImage.sprite = _ranks[_towerExp.Level];
        else
            _rankImage.sprite = _ranks[_ranks.Length - 1];
        TextColor();
    }

    public Sprite GetRankSprite(int level)
    {
        return _ranks[level];
    }

    private void TextColor()
    {
        if (GameData.Money < _upgradeCost)
            _upgrade.color = Color.red;
        else _upgrade.color = Color.white;
    }
}