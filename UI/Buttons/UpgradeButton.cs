using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private GameObject _upgradeIcons;

    public void ShowUpgradeIcons()
    {
        _upgradeIcons.SetActive(true);
    }

    public void HideUpgradeIcons()
    {
        _upgradeIcons.SetActive(false);
    }
}