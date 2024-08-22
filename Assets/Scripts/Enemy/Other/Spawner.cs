using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy, _spawnPoints;
    private int _waveSize = 5;
    private int _bossLevel = 5;
    private int _currentEnemyLevel = 0;
    private WaitForSeconds _spawnTimer;
    private WaitForSeconds _nextLevelTimer;
    private WaitForSeconds _bossTimer;
    private bool _isHardModeActive;

    private void Start()
    {
        _nextLevelTimer = new WaitForSeconds(4);
        _bossTimer = new WaitForSeconds(9);
        _spawnTimer = new WaitForSeconds(.45f);
        StartCoroutine(StartSpawner());
    }
    private IEnumerator StartSpawner()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(ActivateSpawner(_currentEnemyLevel));
    }

    private void BossLevel()
    {
        _currentEnemyLevel++;
        _waveSize = 1;
        StartCoroutine(TimeBeforeNextLevelAfterBoss());
    }

    private IEnumerator TimeBeforeNextLevelAfterBoss()
    {
        SpawnBoss();
        yield return _bossTimer;
        _currentEnemyLevel++;
        _waveSize = 5;
        _bossLevel += 5;
        GameData.NextLevel();
        StartCoroutine(ActivateSpawner(_currentEnemyLevel));
    }

    private IEnumerator TimeBeforeNextLevel()
    {
        yield return _nextLevelTimer;
        GameData.NextLevel();
        if (GameData.Level != _bossLevel)
        {
            _waveSize *= 2;
            StartCoroutine(ActivateSpawner(_currentEnemyLevel));
        }
        else
        {
            BossLevel();
        }
    }

    private IEnumerator ActivateSpawner(int currentEnemyLevel)
    {
        if (_currentEnemyLevel == 18)
            Camera.main.GetComponent<BackGroundMusic>().ChangeBackgroundMusic();
        if (_currentEnemyLevel == 52 && !_isHardModeActive)
        {
            _isHardModeActive = true;
            _waveSize = 10;
            _nextLevelTimer = new WaitForSeconds(1.3f);
            _spawnTimer = new WaitForSeconds(.25f);
        }

        int enemyCounter = 0;
        while (enemyCounter < _waveSize)
        {
            int randomSpawnPoint = Random.Range(0, _spawnPoints.Length);
            var enemy = Instantiate(_enemy[currentEnemyLevel], _spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyMovementAI>().SetPathPoints(_spawnPoints[randomSpawnPoint].GetComponent<SpawnPoint>().GetPath());
            EnemyTargetList.AddEnemy(enemy);
            enemyCounter++;
            yield return _spawnTimer;
        }
        StartCoroutine(TimeBeforeNextLevel());
    }
    private void SpawnBoss()
    {
        int randomSpawnPoint = Random.Range(0, _spawnPoints.Length);
        var enemy = Instantiate(_enemy[_currentEnemyLevel], _spawnPoints[randomSpawnPoint].transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyMovementAI>().SetPathPoints(_spawnPoints[randomSpawnPoint].GetComponent<SpawnPoint>().GetPath());
        EnemyTargetList.AddEnemy(enemy);
    }
}