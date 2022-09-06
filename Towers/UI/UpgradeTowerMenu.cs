using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTowerMenu : MonoBehaviour
{
    [SerializeField] private Sprite[] _ranks;
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameObject _upgradeMenu;
    [SerializeField] private Sprite[] _towerSprite;
    [SerializeField] private TextMeshProUGUI _damage, _range, _attackSpeed, _level, _upgrade, _kills;
    [SerializeField] private Image _rankImage;
    [SerializeField] private AudioClip _sellTowerSound , _upgradeTowerSound;
    [SerializeField] private GameObject _installationPointIndicator;
    [SerializeField] private AudioSource _audioSource;
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
        if (_gameData.Money >= _upgradeCost)
        {
            _audioSource.PlayOneShot(_upgradeTowerSound);
            _installationPoint.UpgradeTower(_upgradeCost);
            _gameData.UpgradeTower(_upgradeCost);
            _tower.UpgradeTower();
            RefreshMenu();
        }
        else Debug.Log("Not enough money");
    }

    public void SellTower()
    {
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
        _level.text = _towerExp.Level.ToString();
        _rankImage.sprite = _ranks[_towerExp.Level];
        TextColor();
    }

    private void TextColor()
    {
        if (_gameData.Money < _upgradeCost)
            _upgrade.color = Color.red;
        else _upgrade.color = Color.white;
    }
}