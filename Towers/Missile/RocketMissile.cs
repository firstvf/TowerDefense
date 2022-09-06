using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RocketMissile : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;
    [SerializeField] private float _moveSpeed;
    private WaitForSeconds _timer;
    private Tower _tower;
    private float _explosionRadius;
    private AudioSource _audioSource;
    private int _damage;
    private bool _isTargetSet;
    private Vector3 _desiredPoint;
    private Action<RocketMissile> _missile;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _timer = new WaitForSeconds(1f);
    }

    private void Update()
    {
        if (_isTargetSet)
            FlyToSpecifiedPoint();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

    public void ResetMissileInPool(Action<RocketMissile> missile)
    {
        _missile = missile;
    }

    public void SetTarget(Vector3 desiredPoint, Tower tower, int damage, float radius)
    {
        _explosionRadius = radius / 3;
        _tower = tower;
        _damage = damage;
        _desiredPoint = desiredPoint;
        _isTargetSet = true;
    }

    private void ExplosionArea()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var collider in colliders)
            if (collider.TryGetComponent(out Enemy enemy))            
                if (enemy.TakeDamage(_damage))
                    _tower.AddExperience(enemy.Experience);            
    }

    private IEnumerator TimeBeforeDestroy()
    {
        _audioSource.Play();
        _rocket.SetActive(false);
        yield return _timer;
        _rocket.SetActive(true);
        _missile(this);
    }

    private void FlyToSpecifiedPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _desiredPoint, _moveSpeed * Time.deltaTime);
        transform.LookAt(_desiredPoint);
        if (transform.position == _desiredPoint && _isTargetSet)
        {
            _isTargetSet = false;
            StartCoroutine(TimeBeforeDestroy());
            ExplosionArea();
        }
    }
}
