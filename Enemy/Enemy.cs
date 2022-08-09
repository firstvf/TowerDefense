using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    abstract public int Health { get;protected set; }
    abstract protected int Experience { get; set; }
    abstract protected int Money { get; set; }
    abstract protected float Speed { get; set; }
    private bool _isDead => Health <= 0;
    private bool _isAbleAnAward = true;
    private EnemyHealthBar _healthBar;

    public void GetDamage(int damage, Tower tower)
    {
        if (_healthBar == null)
            _healthBar = GetComponent<EnemyHealthBar>();
        Health -= damage;
        _healthBar.UpdateHealthBar(Health);
        if (_isDead && _isAbleAnAward)
        {
            tower.GetExperience(Experience);
            _isAbleAnAward = false;
            GetLoot();
            Death();
        }
    }

    public float GetSpeed() => Speed;

    private void Death()
    {
        Destroy(gameObject);
    }

    private void GetLoot()
    {
        GameData.SetScore();
        GameData.SetMoney(Money);
    }
}
