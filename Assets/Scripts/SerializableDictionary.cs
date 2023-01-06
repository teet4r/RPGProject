using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<Key, Value>
{
    [SerializeField] List<Key> key = new();
    [SerializeField] List<Value> value = new();
}