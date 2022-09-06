using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
    private EnemyObjectsPooler _pooler;
    private int _waveSize = 25;
    private WaitForSeconds _spawnTimer = new WaitForSeconds(.5f);
    private int _spawnCount = 0;
    private EnemyList _enemies;

    private void Start()
    {
       // _pooler = EnemyObjectsPooler.Instance;
    }

    private void OnEnable()
    {

        _enemies = GetComponent<EnemyList>();
        StartCoroutine(SpawnTimer(_spawnCount));
    }

    private IEnumerator SpawnTimer(int count)
    {
        while (count < _waveSize)
        {
            count++;
            EnemySpawner();
            yield return _spawnTimer;
        }
    }

    private void EnemySpawner()
    {
       // var enemy = _pooler.SpawnFromPool("Slime", _spawnPoints[Random.Range(0, 2)]);
       // _enemies.AddEnemy(enemy);
    }

    //private void EnemySpawner()
    //{
    //    var enemy = Instantiate(_enemy,transform.position,Quaternion.identity);
    //    enemy.GetComponent<EnemyMovementAI>().SetPathPoints(_pathPoints);
    //    _enemies.AddEnemy(enemy);
    //}

}
