using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunTower : Tower
{
    public override int Damage { get; protected set; }
    public override float AttackRange { get; protected set; }
    public override float AttackSpeed { get; protected set; }

    protected override void Start()
    {
        base.Start();
        Damage = 10;
        AttackRange = 10;
        AttackSpeed = 0.5f;
    }

    public override void UpgradeTower()
    {
        Damage += 9;
        if (AttackRange < 20)
            AttackRange += 0.2f;
        if (AttackSpeed > 0.35f)
            AttackSpeed -= 0.05f;
    }
}