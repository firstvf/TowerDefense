using UnityEngine;

public class TowerExperienceSystem : MonoBehaviour
{
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public int KillsCount { get; private set; }
    public float AmountExpToLevelUp { get; private set; }

    private Tower _tower;
    private UI_TowerLevelUp _uiTowerLevelUP;

    private void Awake()
    {
        Level = 0;
        _uiTowerLevelUP = GetComponent<UI_TowerLevelUp>();
        _tower = GetComponent<Tower>();
    }

    private void Start()
    {
        AmountExpToLevelUp = 5;
    }

    public void AddExperience(int exp)
    {
        KillsCount++;
        Experience += exp;
        if (Experience >= AmountExpToLevelUp)
        {
            AmountExpToLevelUp *= 1.15f;
            Experience = 0;
            Level++;
            _tower.LevelUp(2 * Level);
            _uiTowerLevelUP.ShowLevelUp();
        }
    }
}