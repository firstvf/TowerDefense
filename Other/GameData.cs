using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static int Money { get; private set; }
    public static int Score { get; private set; }
    public static int Level { get; private set; }

    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _moneyText;
    private static bool _isAbleToChangeMoneyText = true;
    private static bool _isAbleToChangeLevelText = true;
    public static bool MyProperty { get; set; }
    public static bool IsDisableSounds { get; private set; }
    public static bool IsDisableMusic { get; private set; }
    public static bool IsDisableParticles { get; private set; }

    private void Start()
    {
        Level = 1;
        Money = 100;
        UpdateMoneyText();
        UpdateLevelText();
    }

    public static void DisableSounds() => IsDisableSounds = true;

    public static void EnableSounds() => IsDisableSounds = false;

    public static void DisableMusic() => IsDisableMusic = true;

    public static void EnableMusic() => IsDisableMusic = false;

    public static void DisableParticles() => IsDisableParticles = true;

    public static void EnableParticles() => IsDisableParticles = false;

    public static void ClearAllData()
    {
        EnemyTargetList.ClearList();
    }

    private void Update()
    {
        if (_isAbleToChangeMoneyText)
        {
            _isAbleToChangeMoneyText = false;
            _moneyText.text = Money.ToString();
        }
        if (_isAbleToChangeLevelText)
        {
            _isAbleToChangeLevelText = false;
            _levelText.text = Level.ToString();
        }
    }

    public static void NextLevel()
    {
        Level++;
        UpdateLevelText();
    }
    public static void AddScore() => Score++;
    public static void UpgradeTower(int money) => BuyTower(money);

    public static void BuyTower(int money)
    {
        Money -= money;
        UpdateMoneyText();
    }

    public static void SellTower(int money)
    {
        Money += (int)(money / 1.5f);
        UpdateMoneyText();
    }

    public static void AddMoney(int money)
    {
        Money += money;
        UpdateMoneyText();
    }
    private static void UpdateLevelText() => _isAbleToChangeLevelText = true;

    private static void UpdateMoneyText() => _isAbleToChangeMoneyText = true;
}