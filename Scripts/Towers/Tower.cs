using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    abstract protected int Damage { get; set; }
    abstract protected int AttackRadius { get; set; }
    abstract protected float AttackSpeed { get; set; }
    protected GameObject Target;
    private AudioSource _audioSource => GetComponent<AudioSource>();
    private List<GameObject> _enemyList => EnemyList.GetEnemyList();
    private WaitForSeconds _attackCooldown => new WaitForSeconds(AttackSpeed);
    //private ParticleSystem _particle => GetComponent<ParticleSystem>();
    private Coroutine _attackCoroutine;
    private bool _isAbleToFindTarget = true;
    private bool _isCoroutineStart;
    private int _experience;



    private void Update()
    {
        SearchEnemy();
        if (!_isAbleToFindTarget)
            SetTarget();
    }

    private void LevelUP()
    {
        Damage++;
        // AttackSpeed -= 0.1f;
    }

    public void GetExperience(int exp)
    {
        _experience += exp;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRadius);
    }

    private void SearchEnemy()
    {
        if (_isAbleToFindTarget && _enemyList.Count > 0)
            foreach (var enemy in _enemyList)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < AttackRadius)
                {
                    Target = enemy.gameObject;
                    _isAbleToFindTarget = false;
                }
            }
    }

    private void SetTarget()
    {
        if (_enemyList.Contains(Target) && Vector3.Distance(transform.position, Target.transform.position) < AttackRadius)
        {
            transform.LookAt(Target.transform.position);
            if (!_isCoroutineStart)
                _attackCoroutine = StartCoroutine(CooldownBeforeAttack());
        }
        else _isAbleToFindTarget = true;
    }

    virtual protected void ShootSettings()
    {
        _audioSource.Play();
      //  _particle.Play();
        DamageTarget();
    }

    virtual protected void DamageTarget()
    {
        Target.GetComponent<Enemy>().TakeDamage(Damage, this);
    }

    private IEnumerator CooldownBeforeAttack()
    {
        _isCoroutineStart = true;
        while (true)
        {
            if (!_isAbleToFindTarget && Target != null)
            {
                ShootSettings();
            }
            else if (_enemyList.Count == 0)
            {
                StopCoroutine(_attackCoroutine);
                _isCoroutineStart = false;
            }
            yield return _attackCooldown;
        }
    }
}