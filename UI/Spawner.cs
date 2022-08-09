using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private delegate void _throneDefeated(); // Добавить потом
    private _throneDefeated _isTheThroneDestroyed { get; set; } // Добавить потом
    private int _waveSize = 4;
    // private Coroutine _spawnCoroutine;
    private WaitForSeconds _spawnTimer = new WaitForSeconds(1.5f);
    private int _spawnCount = 0;

    private void Start()
    {
        //  _spawnCoroutine = StartCoroutine(SpawnTimer(_spawnCount));
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnTimer(_spawnCount));
        // Debug.Log("If health less than or equal 0 => StopCoroutine(_spawnCoroutine)");
    }

    private IEnumerator SpawnTimer(int count)
    {
        while (count < _waveSize)
        {
            count++;
            //  Debug.Log($"Current count is: {count}");
            EnemySpawner();
            yield return _spawnTimer;
        }
        // Debug.Log("The coroutine stopped");
    }

    private void EnemySpawner()
    {
        Instantiate(_enemy, gameObject.transform.position, Quaternion.identity);
    }

}
