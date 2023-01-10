using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObject/SpawnData")]
public class SpawnData : ScriptableObject
{
    [Tooltip("���� ��������")]
    [UnityEngine.Min(1)]
    public int stage = 1;

    [Tooltip("�Ϲ� ���Ͱ� ������ ��ġ �ĺ�")]
    public Transform[] normalSpawnPoints;
    [Tooltip("���� ���Ͱ� ������ ��ġ �ĺ�")]
    public Transform[] bossSpawnPoints;

    [Tooltip("�ش� ���������� ������ �Ϲ� ���� ������ �̸���")]
    public string[] normalPrefabNames;
    [Tooltip("�ش� ���������� ������ ���� ���� ������ �̸���")]
    public string[] bossPrefabNames;

    [Tooltip("�Ϲ� ���� ���� �ֱ�")]
    [UnityEngine.Min(0.1f)]
    public float spawnRate = 3f;

    [Tooltip("�Ϲ� ���� �ִ� ���� ��")]
    [UnityEngine.Min(0)]
    public int maxCount = 8;
}
