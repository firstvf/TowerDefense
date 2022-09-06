using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherTower : Tower
{
    [SerializeField] private GameObject _missile;
    protected override int Damage { get; set; }
    protected override int AttackRadius { get; set; }
    protected override float AttackSpeed { get; set; }

    private void Start()
    {
        Damage = 15;
        AttackRadius = 15;
        AttackSpeed = 4f;
    }

    protected override void DamageTarget()
    {
        var missile = Instantiate(_missile, transform.position, Quaternion.identity);
        missile.GetComponent<RocketMissile>().SetTransform(Target.transform.position, this, Damage,AttackRadius);
    }
}
