using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretDesign{
    public GameObject prefab;//炮塔的预制体
    public int cost;//花费
    public int SellAmount
    {
        get
        {
            return cost / 2;
        }
    }
}
