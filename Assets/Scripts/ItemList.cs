using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemList<Key, Value>
{
    [SerializeField] List<Key> key = new();
    [SerializeField] List<Value> value = new();

    public Value GetItem(Key _key)
    {
        return value[key.IndexOf(_key)];
    }
}