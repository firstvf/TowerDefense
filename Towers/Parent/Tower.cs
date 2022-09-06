using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    //private ParticleSystem _particle => GetComponent<ParticleSystem>();
    abstract public float AttackRange { get; protected set; }
    abstract public float AttackSpeed { get; protected set; }
    abstract public int Damage { get; protected set; }
    protected GameObject Target;
    private WaitForSeconds _attackCooldown;
    private WaitForSeconds _findTargetCooldown;
    private List<GameObject> _enemyList;
    private TowerExperienceSystem _towerExp;
    private AudioSource _audioSource;
    private Coroutine _attackCoroutine;
    private bool _isAbleToFindTarget = true;
    private bool _isCoroutineStart;

    private void Awake()
    {
        _towerExp = GetComponent<TowerExperienceSystem>();
        _audioSource = GetComponent<AudioSource>();
    }
    protected virtual void Start()
    {
        _findTargetCooldown = new WaitForSeconds(.5f);
        _enemyList = EnemyTargetList.GetEnemyList();
        StartCoroutine(FindTarget());
    }
    private IEnumerator FindTarget()
    {
        while (true)
        {
            if (_isAbleToFindTarget)
                SearchEnemy();
            else SetTarget();

            yield return _findTargetCooldown;
        }
    }

    public void LevelUp(int damage)
    {
        Damage += damage;
        AttackRange += 0.1f;
    }
    public virtual void UpgradeTower() { }
    public void AddExperience(int exp) => _towerExp.AddExperience(exp);

    virtual protected void ShootSettings()
    {
        _audioSource.Play();
        //  _particle.Play();
        DamageTarget();
    }

    virtual protected void DamageTarget()
    {
        if (Target.GetComponent<Enemy>().TakeDamage(Damage))
            AddExperience(Target.GetComponent<Enemy>().Experience);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    private void SearchEnemy()
    {
        foreach (var enemy in _enemyList)
            if (_isAbleToFindTarget && Vector3.Distance(transform.position, enemy.transform.position) < AttackRange)
            {
                Target = enemy.gameObject;
                _isAbleToFindTarget = false;
            }
    }

    private void SetTarget()
    {
        if (_enemyList.Contains(Target) && Vector3.Distance(transform.position, Target.transform.position) < AttackRange)
        {
            transform.LookAt(Target.transform.position);
            if (!_isCoroutineStart)
                _attackCoroutine = StartCoroutine(ReloadingBetweenAttack());
        }
        else _isAbleToFindTarget = true;
    }

    private IEnumerator ReloadingBetweenAttack()
    {
        if (_attackCooldown == null)
            _attackCooldown = new WaitForSeconds(AttackSpeed);

        _isCoroutineStart = true;
        while (true)
        {
            if (!_isAbleToFindTarget && Target != null)
                ShootSettings();
            else if (_enemyList.Count == 0)
            {
                StopCoroutine(_attackCoroutine);
                _isCoroutineStart = false;
            }
            yield return _attackCooldown;
        }
    }
}