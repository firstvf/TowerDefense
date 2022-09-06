using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _installationPointIndicator;
    [SerializeField] private TextMeshProUGUI[] _towerCost;
    [SerializeField] private AudioClip _buildTowerSound;
    [SerializeField] private GameObject[] _tower;
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameObject _shop;
    [SerializeField] private AudioSource _audioSource;
    private WaitForSeconds _time;
    private Coroutine _reloadMenuCoroutine;
    private Transform _setPosition;

    private void Start()
    {
        _time = new WaitForSeconds(1f);
    }

    public void OpenShopUI(Transform setPosition)
    {
        _installationPointIndicator.transform.position = setPosition.position;
        _installationPointIndicator.SetActive(true);
        _setPosition = setPosition;
        _shop.SetActive(true);
        _reloadMenuCoroutine = StartCoroutine(ReloadingWhileMenuIsOpened());
    }
    public void CloseShopUI()
    {
        _installationPointIndicator.SetActive(false);
        StopCoroutine(_reloadMenuCoroutine);
        _setPosition = null;
        _shop.SetActive(false);
    }

    public void BuyTurretTower()
    {
        if (_setPosition.GetComponent<TowerInstallationPoint>().IsPointEmpty && _gameData.Money >= 10)
            SetTowerOnPoint(_tower[0], 10);
    }

    public void BuyMachineGunTower()
    {
        if (_setPosition.GetComponent<TowerInstallationPoint>().IsPointEmpty && _gameData.Money >= 25)
            SetTowerOnPoint(_tower[1], 25);
    }

    public void BuyRocketTower()
    {
        if (_setPosition.GetComponent<TowerInstallationPoint>().IsPointEmpty && _gameData.Money >= 50)
            SetTowerOnPoint(_tower[2], 50);
    }

    private void PaintTextIfNotEnoughMoney()
    {
        for (int i = 0; i < _towerCost.Length; i++)
        {
            if (Convert.ToInt32(_towerCost[i].text) > _gameData.Money)
                _towerCost[i].color = Color.red;
            else _towerCost[i].color = Color.green;
        }
    }

    private IEnumerator ReloadingWhileMenuIsOpened()
    {
        while (true)
        {
            PaintTextIfNotEnoughMoney();
            yield return _time;
        }
    }

    private void SetTowerOnPoint(GameObject tower, int money)
    {
        _audioSource.PlayOneShot(_buildTowerSound);
        PaintTextIfNotEnoughMoney();
        var towerRef = Instantiate(tower, new Vector3(_setPosition.position.x, _setPosition.position.y + 1, _setPosition.position.z), Quaternion.identity);
        _setPosition.GetComponent<TowerInstallationPoint>().BuildTower(towerRef, money);
        CloseShopUI();
    }
}