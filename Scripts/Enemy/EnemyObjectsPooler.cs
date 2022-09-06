using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectsPooler : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _spawnAmount;
    //private objectpool

    /*
    [System.Serializable]
    public class Pool
    {
        public GameObject Enemy;
        public string Tag;
        public int Size;
    }

    public static EnemyObjectsPooler Instance;
    private void Awake()
    {
        Instance = this;
    }


    [SerializeField] private List<Pool> _pools;
    private Dictionary<string, Queue<GameObject>> _poolDictionary;

    private void Start()
    {
        PoolQueue();
    }

    private void PoolQueue()
    {
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.Size; i++)
            {
                var enemy = Instantiate(pool.Enemy);
                enemy.SetActive(false);
                objectPool.Enqueue(enemy);
            }

            _poolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, GameObject spawnPoint)
    {
        if (!_poolDictionary.ContainsKey(tag))
        {
            Debug.Log($"Invalid dictionary key: {tag}");
            return null;
        }

        GameObject spawnEnemy = _poolDictionary[tag].Dequeue();
        spawnEnemy.SetActive(true);
        spawnEnemy.transform.position = spawnPoint.transform.position;
        spawnEnemy.GetComponent<EnemyMovementAI>().SetPathPoints(spawnPoint.GetComponent<SpawnPoint>().GetPath());
        _poolDictionary[tag].Enqueue(spawnEnemy);

        return spawnEnemy;
    }
    */
}
