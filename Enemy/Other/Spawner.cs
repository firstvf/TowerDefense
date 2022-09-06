using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy , _spawnPoints;
   // private EnemiesPooler _pooler;
    private int _waveSize = 150;
    private WaitForSeconds _spawnTimer;

    private void Start()
    {
        _spawnTimer = new WaitForSeconds(.15f);
        StartCoroutine(SpawnTimer());
    }

    private IEnumerator SpawnTimer()
    {
        int enemyCounter = 0;
        while (enemyCounter < _waveSize)
        {
            int randomSpawnPoint = Random.Range(0, _spawnPoints.Length);
            var enemy = Instantiate(_enemy[0],_spawnPoints[randomSpawnPoint].transform.position,Quaternion.identity);
            enemy.GetComponent<EnemyMovementAI>().SetPathPoints(_spawnPoints[randomSpawnPoint].GetComponent<SpawnPoint>().GetPath());
            EnemyTargetList.AddEnemy(enemy);
            enemyCounter++;
            yield return _spawnTimer;
        }
    }
}