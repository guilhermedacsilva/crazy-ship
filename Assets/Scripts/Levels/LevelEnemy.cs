using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelEnemy
{
    private string prefabPath;
    private int quantity;
    private int spawnTimeMin, spawnTimeMax;

    public LevelEnemy(string pf, int q, int sMin, int sMax)
    {
        prefabPath = pf;
        quantity = q;
        spawnTimeMin = sMin;
        spawnTimeMax = sMax;
    }

    public string PrefabPath
    {
        get
        {
            return prefabPath;
        }
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }
    }

    public int SpawnTimeMin
    {
        get
        {
            return spawnTimeMin;
        }
    }

    public int SpawnTimeMax
    {
        get
        {
            return spawnTimeMax;
        }
    }
}