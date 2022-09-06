using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject[] _tower;
    private Transform _setPosition;


    public void OpenShopUI(Transform setPosition)
    {
        _setPosition = setPosition;
        _shop.SetActive(true);
    }

    public void TurretTower()
    {//if money >= 10        
        if (_setPosition.GetComponent<TowerInstallationPoint>().IsPointEmpty())
            SetTowerOnPoint(_tower[0]);
    }

    public void MachineGunTower()
    {//if money >= 35
        if (_setPosition.GetComponent<TowerInstallationPoint>().IsPointEmpty())
            SetTowerOnPoint(_tower[1]);
    }

    public void RocketTower()
    {//if money >= 100
        if (_setPosition.GetComponent<TowerInstallationPoint>().IsPointEmpty())
            SetTowerOnPoint(_tower[2]);
    }

    private void SetTowerOnPoint(GameObject tower)
    {
        _setPosition.GetComponent<TowerInstallationPoint>().BuildTower();
        Instantiate(tower, new Vector3(_setPosition.position.x, _setPosition.position.y + 1, _setPosition.position.z), Quaternion.identity);
    }

    private void CloseShopUI()
    {
        _setPosition = null;
        _shop.SetActive(false);
    }
}
