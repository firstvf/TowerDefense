using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerExperienceSystem : MonoBehaviour
{
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public int KillsCount { get; private set; }
    public int AmountExpToLevelUp { get; private set; }
    private Tower _tower;

    private void Awake()
    {
        _tower = GetComponent<Tower>();
    }

    private void Start()
    {
        AmountExpToLevelUp = 10;
    }

    public void AddExperience(int exp)
    {
        KillsCount++;
        Experience += exp;
        if (Experience >= AmountExpToLevelUp)
        {
            AmountExpToLevelUp *= 2;
            Level++;
            _tower.LevelUp(5 * Level);
        }
    }
}
