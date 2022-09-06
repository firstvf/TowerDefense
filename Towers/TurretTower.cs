using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTower : Tower
{
    public override int Damage { get; protected set; }
    public override float AttackRange { get; protected set; }
    public override float AttackSpeed { get; protected set; }

    protected override void Start()
    {
        base.Start();
        Damage = 15;
        AttackRange = 12;
        AttackSpeed = 1.5f;
    }

    public override void UpgradeTower()
    {
        Damage += 10;
        if (AttackRange < 25)
            AttackRange += 0.5f;
        if (AttackSpeed > 0.8f)
            AttackSpeed -= 0.1f;
    }
}
