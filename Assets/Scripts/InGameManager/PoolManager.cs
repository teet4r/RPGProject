using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance = null;
    [SerializeField] ObjectPool[] pools;
    readonly Dictionary<string, ObjectPool> poolDictionary = new Dictionary<string, ObjectPool>();

    void Awake()
    {
        if (instance == null)
            instance = this;

        Initialize();
    }

    public ObjectPool Get(string poolObjName)
    {
        if (!poolDictionary.ContainsKey(poolObjName))
            throw new System.Exception("This name of pool doesn't exist.");
        return poolDictionary[poolObjName];
    }

    void Initialize()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            if (poolDictionary.ContainsKey(pools[i].name))
                throw new System.Exception("There are two or more same names of pool!");
            poolDictionary.Add(pools[i].name, pools[i]);
        }
    }
}