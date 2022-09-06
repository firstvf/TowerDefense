using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetList : MonoBehaviour
{
    private static List<GameObject> _enemyList = new List<GameObject>();

    public static List<GameObject> GetEnemyList() => _enemyList;

    public static void AddEnemy(GameObject enemy)
    {
        if (!_enemyList.Contains(enemy))
            _enemyList.Add(enemy);
    }

    public static void RemoveEnemy(GameObject enemy)
    {
        _enemyList.Remove(enemy);
    }
}