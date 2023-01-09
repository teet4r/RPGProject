using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance = null;
    public int PoolSize
    {
        get { return _prefabs.Length; }
    }
    [SerializeField] GameObject[] _prefabs;
    [Tooltip("Make prefab's clones in advance.")]
    [SerializeField] int _initialCount = 3;
    Dictionary<string, GameObject> _dictionary = new Dictionary<string, GameObject>();
    Dictionary<string, Queue<GameObject>> _qDictionary = new Dictionary<string, Queue<GameObject>>();

    void Awake()
    {
        if (instance == null)
            instance = this;

        for (int i = 0; i < _prefabs.Length; i++)
        {
            if (_prefabs[i] == null)
                throw new System.Exception("Object pool has null game object(s).");

            var prefabName = _prefabs[i].name;
            _dictionary.Add(prefabName, _prefabs[i]);
            _qDictionary.Add(prefabName, new Queue<GameObject>());
            for (int j = 0; j < _initialCount; j++)
            {
                var clone = Instantiate(_prefabs[i], transform);
                clone.name = prefabName;
                clone.SetActive(false);
                _qDictionary[prefabName].Enqueue(clone);
            }
        }
    }

    public GameObject Get(string prefabName)
    {
        if (!_dictionary.ContainsKey(prefabName))
        {
            Debug.LogError("This name of prefab doesn't exist.");
            return null;
        }

        if (_qDictionary[prefabName].Count == 0)
        {
            var clone = Instantiate(_dictionary[prefabName], transform);
            clone.name = prefabName;
            clone.SetActive(false);
            return clone;
        }
        var obj = _qDictionary[prefabName].Dequeue();
        return obj;
    }
    public GameObject GetRandom()
    {
        return Get(_prefabs[Random.Range(0, _prefabs.Length)].name);
    }
    /// <summary>
    /// Return all instantiated prefabs.
    /// </summary>
    /// <returns>Array Type</returns>
    public GameObject[] GetAll()
    {
        var gameObjects = new GameObject[_prefabs.Length];
        for (int i = 0; i < _prefabs.Length; i++)
            gameObjects[i] = Get(_prefabs[i].name);
        return gameObjects;
    }
    public void Put(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("This object is null.");
            Destroy(obj);
            return;
        }
        else if (!_dictionary.ContainsKey(obj.name))
        {
            Debug.LogError("Object pool doesn't contain this object's name.");
            Destroy(obj);
            return;
        }

        obj.SetActive(false);
        _qDictionary[obj.name].Enqueue(obj);
    }
    public void Clear()
    {
        foreach (var pair in _qDictionary)
            while (pair.Value.Count != 0)
                Destroy(pair.Value.Dequeue());
    }
}
