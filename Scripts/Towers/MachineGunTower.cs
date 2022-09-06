using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunTower : Tower
{
    protected override int Damage { get; set; }
    protected override int AttackRadius { get; set; }
    protected override float AttackSpeed { get; set; }

    private void Start()
    {
        Damage = 5;
        AttackRadius = 6;
        AttackSpeed = 0.4f;
    }
}