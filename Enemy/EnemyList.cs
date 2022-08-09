using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    private static List<EnemyList> _enemyList = new List<EnemyList>();

    public static List<EnemyList> GetEnemyList() => _enemyList;

    private void Awake()
    {
        _enemyList.Add(this);
    }
}
