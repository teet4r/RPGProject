using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObject/SpawnData")]
public class SpawnData : ScriptableObject
{
    [Tooltip("현재 스테이지")]
    [UnityEngine.Min(1)]
    public int stage = 1;

    [Tooltip("일반 몬스터가 생성될 위치 후보")]
    public Transform[] normalSpawnPoints;
    [Tooltip("보스 몬스터가 생성될 위치 후보")]
    public Transform[] bossSpawnPoints;

    [Tooltip("해당 스테이지에 등장할 일반 몬스터 프리팹 이름들")]
    public string[] normalPrefabNames;
    [Tooltip("해당 스테이지에 등장할 보스 몬스터 프리팹 이름들")]
    public string[] bossPrefabNames;

    [Tooltip("일반 몬스터 생성 주기")]
    [UnityEngine.Min(0.1f)]
    public float spawnRate = 3f;

    [Tooltip("일반 몬스터 최대 생성 수")]
    [UnityEngine.Min(0)]
    public int maxCount = 8;
}
