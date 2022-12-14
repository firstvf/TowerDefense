using UnityEngine;
using UnityEngine.Pool;

public class MissilesPooler : MonoBehaviour
{
    [SerializeField] private GameObject _rocket;
    private ObjectPool<GameObject> _pooler;
    private int _poolSize = 3;

    private void Start()
    {
        PoolMissiles();
    }

    public GameObject GetPool(Vector3 position, Quaternion rotation)
    {
        var missile = _pooler.Get();
        missile.transform.position = position;
        missile.transform.rotation = rotation;
        missile.GetComponent<RocketMissile>().ResetMissileInPool(SetMissileInPool);
        missile.SetActive(true);
        return missile;

    }

    private void PoolMissiles()
    {
        _pooler = new ObjectPool<GameObject>(() =>
        { return Instantiate(_rocket); },                   // Create func
        rocket => { rocket.gameObject.SetActive(false); },  // Action on Get
        rocket => { rocket.gameObject.SetActive(false); },  // Action on Release
        rocket => { Destroy(rocket.gameObject); },          // Action on destroy
        false, _poolSize, _poolSize * 2);                   // collection check , pool size , max capacity
    }

    public void SetMissileInPool(RocketMissile missile)
    {
        _pooler.Release(missile.gameObject);
    }
}