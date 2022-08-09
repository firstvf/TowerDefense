using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherTower : Tower
{
    protected override int Damage { get; set  ; }
    protected override int AttackRadius { get ; set ; }
    protected override float AttackSpeed { get; set; }

    protected override void ShootSound()
    {
        throw new System.NotImplementedException();
    }

    private void Start()
    {
        Damage = 15;
        AttackRadius = 15;
        AttackSpeed = 3f;
    }
}
