using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    public int StartMoney = 500;
    public static int Money;
    public int StartLives = 3;//初始生命值
    public static int Lives;

    public static int Rounds;//回合
    private void Awake()
    {
        Money = StartMoney;
        Lives = StartLives;
        Rounds = 0;
    }
}
