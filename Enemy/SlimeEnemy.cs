using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeEnemy : Enemy
{
    public override int Health { get; protected set; }
    public override int Experience { get; protected set; }
    public override int Money { get; protected set; }
    public override float Speed { get; protected set; }

    protected override void Awake()
    {
        base.Awake();
        Speed = 2.5f;
    }

    private void Start()
    {
        Experience = 1;
        Health = 30;
        Money = 1;
    }
}