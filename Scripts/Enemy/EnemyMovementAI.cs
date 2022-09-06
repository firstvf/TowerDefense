using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    private GameObject[] _pathPoints;
    private float _movementSpeed => GetComponent<Enemy>().GetSpeed();
    private Transform _destinationPoint;
    private bool _ableToMove = true;
    private int _pathCount = 0;
    private EnemyHealthBar _healthBar;

    private void Start()
    {

    }

    public void SetPathPoints(GameObject[] pathPoints)
    {
        _pathPoints = pathPoints;
        _healthBar = GetComponent<EnemyHealthBar>();
        _destinationPoint = _pathPoints[_pathCount].transform;
        transform.LookAt(_destinationPoint);
    }

    private void Update()
    {
            MoveToDestinationPoint();
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
            _healthBar.RotationHealthBar();
        }

        transform.position = Vector3.MoveTowards(transform.position, _destinationPoint.position, _movementSpeed * Time.deltaTime);
    }
}
