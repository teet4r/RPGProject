using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] float _spawnRate = 3f;
    [SerializeField] int _maxSpawnCount = 10;
    Coroutine _spawnCor = null;
    
    void Start()
    {
        StartSpawn();
    }

    public void StartSpawn()
    {
        if (_spawnCor == null)
            _spawnCor = StartCoroutine(_RandomSpawn());
    }
    public void StopSpawn()
    {
        if (_spawnCor != null)
            StopCoroutine(_spawnCor);
    }
    IEnumerator _RandomSpawn()
    {
        WaitForSeconds wfs = new WaitForSeconds(_spawnRate);
        string[] monsterPrefabNames =
        {
            "ChestMonster"
        };
        for (int i = 0; i < _maxSpawnCount; i++)
        {
            var obj = ObjectPool.instance.Get(monsterPrefabNames[Random.Range(0, monsterPrefabNames.Length)]);
            obj.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            obj.SetActive(true);
            yield return wfs;
        }
        _spawnCor = null;
    }
}
