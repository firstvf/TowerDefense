using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UI_TowerLevelUp : MonoBehaviour
{
    [SerializeField] private GameObject _levelUpCanvas;
    [SerializeField] private Image _currentLevelSprite;
    private UpgradeTowerMenu _upgradeTowerMenu;
    private WaitForSeconds _closeUiTimer;
    private TowerExperienceSystem _towerExp;
    private Camera _mainCamera;

    private void Start()
    {
        _towerExp = GetComponent<TowerExperienceSystem>();
        _mainCamera = Camera.main;
        _closeUiTimer = new WaitForSeconds(2.3f);
    }

    public void SetUpgradeMenu(UpgradeTowerMenu upgradeTowerMenu)
    {
        _upgradeTowerMenu = upgradeTowerMenu;
    }

    public void ShowLevelUp()
    {
        _levelUpCanvas.transform.LookAt(_mainCamera.transform);
        _currentLevelSprite.sprite = _upgradeTowerMenu.GetRankSprite(_towerExp.Level);
        _levelUpCanvas.SetActive(true);
        StartCoroutine(TimeBeforeClose());
    }

    private IEnumerator TimeBeforeClose()
    {
        yield return _closeUiTimer;
        _levelUpCanvas.SetActive(false);
    }
}