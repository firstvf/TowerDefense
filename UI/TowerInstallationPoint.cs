using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInstallationPoint : MonoBehaviour
{
    [SerializeField] private ShopUI _shopUI;
    private bool _isPointEmpty;

    private void Start()
    {
        _isPointEmpty = true;
    }

    public bool IsPointEmpty() => _isPointEmpty;    

    public void BuildTower()
    {
        _isPointEmpty = false;
    }

    public void DestroyTower()
    {
        _isPointEmpty = true;
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log(_isPointEmpty);

        Debug.Log("open");
        _shopUI.OpenShopUI(gameObject.transform);
    }
}
