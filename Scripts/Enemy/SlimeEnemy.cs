using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeEnemy : Enemy
{
    public override int Health { get; protected set; }
    protected override int Experience { get; set; }
    protected override int Money { get; set; }
    protected override float Speed { get; set; }

    private void Start()
    {
        Experience = 1;
        Health = 30;
        Money = 1;
        Speed = 2.5f;
    }
}
