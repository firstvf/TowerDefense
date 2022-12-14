using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    abstract public float AttackRange { get; protected set; }
    abstract public float AttackSpeed { get; protected set; }
    abstract public int Damage { get; protected set; }

    private ParticleSystem _particle;
    protected Enemy Target;
    private GameObject _targetObject;
    private WaitForSeconds _attackCooldown;
    private List<GameObject> _enemyList;
    private TowerExperienceSystem _towerExp;
    private AudioSource _audioSource;
    private Coroutine _attackCoroutine;
    private bool _isAbleToFindTarget = true;
    private bool _isCoroutineStart;
    private Sprite _towerSprite;

    protected virtual void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _towerExp = GetComponent<TowerExperienceSystem>();
        _audioSource = GetComponent<AudioSource>();
    }
    protected virtual void Start()
    {
        _enemyList = EnemyTargetList.GetEnemyList();
        _attackCooldown = new WaitForSeconds(AttackSpeed);
    }
    private void Update()
    {
        if (_isAbleToFindTarget)
            SearchEnemy();
        else SetTarget();
    }

    public virtual Sprite GetTowerSprite() => _towerSprite;

    public void LevelUp(int damage)
    {
        Damage += damage;
        AttackRange += 0.1f;
    }
    public virtual void UpgradeTower() { }
    public void AddExperience(int exp) => _towerExp.AddExperience(exp);

    virtual protected void ShootSettings()
    {
        if (!GameData.IsDisableSounds)
            _audioSource.Play();
        if (!GameData.IsDisableParticles)
            _particle.Play();
        DamageTarget();
    }

    virtual protected void DamageTarget()
    {
        if (Target.TakeDamage(Damage))
            AddExperience(Target.Experience);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }

    private void SearchEnemy()
    {
        foreach (var target in _enemyList)
            if (_isAbleToFindTarget && Vector3.Distance(transform.position, target.transform.position) < AttackRange)
            {
                Target = target.GetComponent<Enemy>();
                _targetObject = target;
                _isAbleToFindTarget = false;
            }
    }

    private void SetTarget()
    {
        if (_enemyList.Contains(_targetObject) && Vector3.Distance(transform.position, Target.transform.position) < AttackRange)
        {
            transform.LookAt(Target.transform.position);
            if (!_isCoroutineStart)
                _attackCoroutine = StartCoroutine(ReloadingBetweenAttack());
        }
        else _isAbleToFindTarget = true;
    }

    private IEnumerator ReloadingBetweenAttack()
    {
        _isCoroutineStart = true;
        while (true)
        {
            if (!_isAbleToFindTarget && Target != null)
                ShootSettings();
            else
            {
                StopCoroutine(_attackCoroutine);
                _isCoroutineStart = false;
            }
            yield return _attackCooldown;
        }
    }
}