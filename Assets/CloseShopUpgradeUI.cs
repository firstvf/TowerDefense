using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShopUpgradeUI : MonoBehaviour
{
    [SerializeField] private GameObject[] _shopUi;

    private void OnMouseDown()
    {
        if (_shopUi[0].activeInHierarchy)        
            _shopUi[0].SetActive(false);

        if (_shopUi[1].activeInHierarchy)
            _shopUi[1].SetActive(false);
    }
}