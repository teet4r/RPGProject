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

[System.Serializable]
public class SerializableDictionary<Key, Value>
{
    [SerializeField] List<Key> key = new();
    [SerializeField] List<Value> value = new();

    public List<Key> Keys { get { return key; } }
    public List<Value> Values { get { return value; } }
    public int Count { get { return key.Count; } }

    public Value GetValue(Key _key)
    {
        return value[key.IndexOf(_key)];
    }
}