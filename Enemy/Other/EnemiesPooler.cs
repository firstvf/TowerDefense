using UnityEngine;
using UnityEngine.Pool;

public class EnemiesPooler : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy;
    [SerializeField] private int _spawnAmount;
    [SerializeField] private GameObject[] _spawnPoints;
    private ObjectPool<GameObject> _pooler;

    public void SetPoolEnemy(int num)
    {
        _pooler = new ObjectPool<GameObject>(() =>
        { return Instantiate(_enemy[num]); },            // create func
        enemy => { enemy.gameObject.SetActive(false); }, // action on get
        enemy => { enemy.gameObject.SetActive(false); }, // action on release
        enemy => { Destroy(enemy); },                    // action on destroy
        false, _spawnAmount, _spawnAmount + 10);         // collection check?; capacity ; max size

        for (int i = 0; i < _spawnAmount; i++)
        {
            var enemy = _pooler.Get();
        }
    }

    public void GetPool()
    {
        int random = Random.Range(0, _spawnPoints.Length);
        var enemy = _pooler.Get();

        enemy.transform.position = _spawnPoints[random].transform.position;
        enemy.GetComponent<EnemyMovementAI>().SetPathPoints(_spawnPoints[random].GetComponent<SpawnPoint>().GetPath());
       // enemy.GetComponent<Enemy>().Init(KillEnemy);
        enemy.SetActive(true);
        EnemyTargetList.AddEnemy(enemy);
    }

    private void KillEnemy(Enemy enemy)
    {
        _pooler.Release(enemy.gameObject);
    }
}