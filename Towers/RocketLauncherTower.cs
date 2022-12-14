using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherTower : Tower
{
    public override int Damage { get; protected set; }
    public override float AttackRange { get; protected set; }
    public override float AttackSpeed { get; protected set; }

    [SerializeField] private Sprite _rocketLauncherSprite;
    private MissilesPooler _missilesPooler;

    protected override void Awake()
    {
        base.Awake();
        _missilesPooler = GetComponent<MissilesPooler>();
    }

    public override Sprite GetTowerSprite() => _rocketLauncherSprite;

    protected override void Start()
    {
        Damage = 25;
        AttackRange = 15;
        AttackSpeed = 3.5f;
        base.Start();
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