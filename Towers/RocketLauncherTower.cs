using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherTower : Tower
{
    public override int Damage { get; protected set; }
    public override float AttackRange { get; protected set; }
    public override float AttackSpeed { get; protected set; }
    private MissilesPooler _missilesPooler;

    private void Awake()
    {
        _missilesPooler = GetComponent<MissilesPooler>();
    }

    protected override void Start()
    {
        base.Start();
        Damage = 30;
        AttackRange = 15;
        AttackSpeed = 4f;
    }

    public override void UpgradeTower()
    {
        Damage += 20;
        if (AttackRange < 30)
            AttackRange += 0.5f;
        if (AttackSpeed > 2)
            AttackSpeed -= 0.2f;
    }

    protected override void DamageTarget()
    {
        var rocket = _missilesPooler.GetPool(transform.position, Quaternion.identity);
        rocket.GetComponent<RocketMissile>().SetTarget(Target.transform.position, this, Damage, AttackRange);
    }
}
