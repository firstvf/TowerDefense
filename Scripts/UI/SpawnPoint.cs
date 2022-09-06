using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject[] _pathPoints;

    public GameObject[] GetPath()
    {
        return _pathPoints;
    }
}
