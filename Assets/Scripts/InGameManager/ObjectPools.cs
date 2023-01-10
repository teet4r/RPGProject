using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    public static ObjectPools instance = null;
    public ObjectPool normalMonsterPool;
    public ObjectPool bossMonsterPool;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
