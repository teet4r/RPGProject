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

    [Tooltip("���Ͱ� ������ ��ġ")]
    public Transform[] spawnPoints;

    [Tooltip("�ش� ���������� ������ ���� ������ �̸���")]
    public string[] monsterPrefabNames;

    [Tooltip("���� ���� �ֱ�")]
    [UnityEngine.Min(0.1f)]
    public float spawnRate = 3f;

    [Tooltip("���� �ִ� ���� ��")]
    [UnityEngine.Min(0)]
    public int maxCount = 8;
}
