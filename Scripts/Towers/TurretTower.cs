using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTower : Tower
{
    protected override int Damage { get; set; }
    protected override int AttackRadius { get; set; }
    protected override float AttackSpeed { get; set; }
       
    private void Start()
    {
        Damage = 12;
        AttackRadius = 12;
        AttackSpeed = 1.5f;
    }
}
