using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;
    public int Stage
    {
        get { return _stage; }
        set
        {
            if (value < 1)
                value = 1;
            _stage = value;
        }
    }
    SpawnData _CurSpawnData
    {
        get
        {
            if (_spawnDatas.Length < Stage)
                throw new System.Exception("Not enough spawn datas.");
            return _spawnDatas[Stage - 1];
        }
    }
    #region Private Variables
    [SerializeField] SpawnData[] _spawnDatas;
    int _stage = 1;
    Coroutine _spawnCor = null;
    #endregion

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        StartSpawn();
    }

    public void StartSpawn()
    {
        var bossObj = ObjectPools.instance.bossMonsterPool.Get(_CurSpawnData.bossPrefabNames[0]);
        bossObj.transform.position = _CurSpawnData.bossSpawnPoints[0].position;
        bossObj.SetActive(true);

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
        WaitForSeconds wfs = new WaitForSeconds(_CurSpawnData.spawnRate);
        for (int i = 0; i < _CurSpawnData.maxCount; i++)
        {
            var obj = ObjectPools.instance.normalMonsterPool.Get(
                _CurSpawnData.normalPrefabNames[Random.Range(0, _CurSpawnData.normalPrefabNames.Length)]
            );
            obj.transform.position = _CurSpawnData.normalSpawnPoints[Random.Range(0, _CurSpawnData.normalSpawnPoints.Length)].position;
            obj.SetActive(true);
            yield return wfs;
        }
        _spawnCor = null;
    }
}
