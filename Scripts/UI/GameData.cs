using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private int _money;
    private int _score;

    public int GetMoney() => _money;

    public int GetScore() => _score;

    public void SetMoney(int money) => _money += money;

    public void SetScore() => _score++;
}
