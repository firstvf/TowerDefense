using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineGunTower : Tower
{
    public override int Damage { get; protected set; }
    public override float AttackRange { get; protected set; }
    public override float AttackSpeed { get; protected set; }

    [SerializeField] private Sprite _machineGunSprite;

    protected override void Start()
    {
        Damage = 10;
        AttackRange = 10;
        AttackSpeed = 0.5f;
        base.Start();
    }
    public override Sprite GetTowerSprite() => _machineGunSprite;

    public override void UpgradeTower()
    {
        Damage += 9;
        if (AttackRange < 20)
            AttackRange += 0.2f;
        if (AttackSpeed > 0.35f)
            AttackSpeed -= 0.05f;
    }
}