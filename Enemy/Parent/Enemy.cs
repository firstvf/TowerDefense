using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    abstract public int Health { get; protected set; }
    abstract public int Experience { get; protected set; }
    abstract public int Money { get; protected set; }
    abstract public float Speed { get; protected set; }
    private bool _isDead => Health <= 0;
    private bool _isAbleAnAward = true;
    private EnemyHealthBar _healthBar;

    protected virtual void Awake()
    {
        _healthBar = GetComponent<EnemyHealthBar>();
    }

    public bool TakeDamage(int damage)
    {
        Health -= damage;
        _healthBar.UpdateHealthBar(Health);
        if (_isDead && _isAbleAnAward)
        {
            _isAbleAnAward = false;
            GetLoot();
            Death();
            return true;
        }
        return false;
    }

    private void Death()
    {
        EnemyTargetList.RemoveEnemy(gameObject);
        Destroy(gameObject);
    }

    private void GetLoot()
    {
        GameData.AddMoney(Money);
        GameData.AddScore();
    }
}