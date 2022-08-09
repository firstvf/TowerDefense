using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] private GameObject[] _pathPoints;
    private float _movementSpeed => GetComponent<Enemy>().GetSpeed();
    private Transform _destinationPoint;
    private bool _ableToMove = true;
    private int _pathCount = 0;
    private EnemyList _enemy;

    private void Start()
    {
        _enemy = GetComponent<EnemyList>();
        _destinationPoint = _pathPoints[_pathCount].transform;
        transform.LookAt(_destinationPoint);
    }

    private void Update()
    {
        MoveToDestinationPoint();
    }

    private void OnDestroy()
    {
        EnemyList.GetEnemyList().Remove(_enemy);
    }

    private void MoveToDestinationPoint()
    {
        if (transform.position == _destinationPoint.position && _pathCount == _pathPoints.Length)
        {
            _ableToMove = false;
            Destroy(gameObject);
        }

        if (_ableToMove && transform.position == _destinationPoint.position)
        {
            _destinationPoint = _pathPoints[_pathCount++].transform;
            transform.LookAt(_destinationPoint);
        }

        transform.position = Vector3.MoveTowards(transform.position, _destinationPoint.position, _movementSpeed * Time.deltaTime);
    }
}
