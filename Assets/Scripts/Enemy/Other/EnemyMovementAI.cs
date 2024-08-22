using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    private Transform _destinationPoint;
    private Transform _moving;
    private EnemyHealthBar _healthBar;
    private GameObject[] _pathPoints;
    private bool _isAbleToMove = true;
    private float _movementSpeed;
    private int _pathCount = 0;

    private void Awake()
    {
        _healthBar = GetComponent<EnemyHealthBar>();
    }

    private void Start()
    {
        _moving = gameObject.transform;
        _movementSpeed = GetComponent<Enemy>().Speed;
    }

    private void Update()
    {
        MoveToDestinationPoint();
    }

    public void SetPathPoints(GameObject[] pathPoints)
    {
        _pathPoints = pathPoints;
        _destinationPoint = _pathPoints[_pathCount].transform;
        transform.LookAt(_destinationPoint);
    }

    private void MoveToDestinationPoint()
    {     
        if (_isAbleToMove && transform.position == _destinationPoint.position)
        {
            _destinationPoint = _pathPoints[_pathCount++].transform;
            transform.LookAt(_destinationPoint);
            _healthBar.RotationHealthBar();
        }

        _moving.position = Vector3.MoveTowards(transform.position, _destinationPoint.position, _movementSpeed * Time.deltaTime);

        if (transform.position == _destinationPoint.position && _pathCount == _pathPoints.Length)
        {
            _isAbleToMove = false;
            EnemyTargetList.RemoveEnemy(gameObject);
            AlliesThrone.Singleton.ChangeHealth();
            Destroy(gameObject);
        }
    }
}