using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static int Money { get; private set; }
    public static int Score { get; private set; }

    public static void SetMoney(int money) => Money += money;

    public static void SetScore() => Score++;
}
