using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTower : Tower
{
    public override int Damage { get; protected set; }
    public override float AttackRange { get; protected set; }
    public override float AttackSpeed { get; protected set; }

    [SerializeField] private Sprite _turretSprite;

    protected override void Start()
    {
        Damage = 15;
        AttackRange = 12;
        AttackSpeed = 1.5f;
        base.Start();
    }

    public override Sprite GetTowerSprite() => _turretSprite;    

    public override void UpgradeTower()
    {
        Damage += 10;
        if (AttackRange < 25)
            AttackRange += 0.5f;
        if (AttackSpeed > 0.8f)
            AttackSpeed -= 0.1f;
    }
}