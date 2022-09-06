using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMissile : MonoBehaviour
{
  //  private ParticleSystem _particle => GetComponent<ParticleSystem>();

    [SerializeField] private GameObject _rocket;
    [SerializeField] private float _moveSpeed;
    private WaitForSeconds _timer = new WaitForSeconds(1f);
    private Tower _tower;
    private float _explosionRadius ;
    private AudioSource _audioSource;
    private int _damage;
    private bool _isTargetSet;
    private Vector3 _desiredPoint;
    private List<GameObject> _enemyList => EnemyList.GetEnemyList();

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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

    private void OnDestroy()
    {
        Debug.Log("destroy");
    }

    public void SetTransform(Vector3 desiredPoint, Tower tower,int damage,int radius)
    {
        _explosionRadius = radius / 3;
        _tower = tower;
        _damage = damage;
        _desiredPoint = desiredPoint;
        _isTargetSet = true;
    }

    private void ExplosionArea()
    {
        foreach (var enemy in _enemyList)        
            if (Vector3.Distance(gameObject.transform.position, enemy.transform.position) < _explosionRadius)            
                enemy.GetComponent<Enemy>().TakeDamage(_damage,_tower);
        StartCoroutine(TimeBeforeDestroy());
    }

    private IEnumerator TimeBeforeDestroy()
    {
        yield return _timer;
        Destroy(gameObject);
    }

    private void FlyToSpecifiedPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _desiredPoint, _moveSpeed*Time.deltaTime);
        transform.LookAt(_desiredPoint);
        if (transform.position == _desiredPoint && _isTargetSet)
        {
            _isTargetSet = false;
            Destroy(_rocket);
            _audioSource.Play();
            ExplosionArea();
          //  _particle.Play();            
        }
    }
}
