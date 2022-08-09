using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    abstract protected int Damage { get; set; }
    abstract protected int AttackRadius { get; set; }
    abstract protected float AttackSpeed { get; set; }
    private GameObject _target;
    private bool _isAbleToFindTarget = true;
    private List<EnemyList> _enemyList => EnemyList.GetEnemyList();
    private WaitForSeconds _attackCooldown => new WaitForSeconds(AttackSpeed);
    private bool _isCoroutineStart;
    private int _experience;

    private void Update()
    {
        SearchEnemy();
        if (!_isAbleToFindTarget)
        {
            SetTarget();
        }
    }

    private void LevelUP()
    {
        Damage++;
        AttackSpeed -= 0.1f;
    }

    public void GetExperience(int exp)
    {
        _experience += exp;
    }

    private void SearchEnemy()
    {
        if (_isAbleToFindTarget && _enemyList.Count > 0)
            foreach (var enemy in _enemyList)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < AttackRadius)
                {
                    _target = enemy.gameObject;
                    _isAbleToFindTarget = false;
                }
            }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRadius);
    }

    private void SetTarget()
    {
        if (_target != null && Vector3.Distance(transform.position, _target.transform.position) < AttackRadius)
            transform.LookAt(_target.transform.position);
        else _isAbleToFindTarget = true;
        AttackEnemy();
    }

    private void AttackEnemy()
    {
        if (!_isAbleToFindTarget && !_isCoroutineStart)
        {
            _isCoroutineStart = true;
            StartCoroutine(CooldownBeforeAttack());
        }
    }

    abstract protected void ShootSound();

    private IEnumerator CooldownBeforeAttack()
    {
        while (!_isAbleToFindTarget)
        {
            ShootSound();
            _target.GetComponent<Enemy>().GetDamage(Damage, this);
            yield return _attackCooldown;
        }
        _isCoroutineStart = false;
    }
}
